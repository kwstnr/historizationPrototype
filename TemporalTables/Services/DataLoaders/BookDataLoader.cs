using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.Services.DataLoaders;

internal static class BookDataLoader
{
    [DataLoader]
    internal static async Task<Dictionary<Guid, IQueryable<Book>>> GetBooksByAuthorIdAsync(
        IReadOnlyList<Guid> keys,
        TemporalTablesDbContext context,
        CancellationToken cancellationToken)
        => await context.Books
            .Where(b => keys.Contains(b.AuthorId))
            .GroupBy(b => b.AuthorId)
            .ToDictionaryAsync(g => g.Key, g => g.AsQueryable(), cancellationToken);

    [DataLoader]
    internal static async Task<Dictionary<Guid, List<Book>>> GetBookHistoryByIdAsync(
        IReadOnlyList<Guid> keys,
        TemporalTablesDbContext context,
        CancellationToken cancellationToken)
        => (await context.Books
                .TemporalAll()
                .Where(b => keys.Contains(b.Id))
                .OrderBy(b => EF.Property<DateTime>(b, "PeriodStart"))
                .ToListAsync(cancellationToken))
            .GroupBy(b => b.Id)
            .ToDictionary(g => g.Key, g => g.ToList());

    [DataLoader]
    internal static async Task<Dictionary<Guid, Book>> GetBookByIdAsync(
        IReadOnlyList<Guid> keys,
        TemporalTablesDbContext context,
        CancellationToken cancellationToken)
        => await context.Books
            .Where(b => keys.Contains(b.Id))
            .ToDictionaryAsync(b => b.Id, cancellationToken);
}