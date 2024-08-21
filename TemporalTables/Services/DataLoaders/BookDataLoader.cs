using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.Services.DataLoaders;

internal static class BookDataLoader
{
    [DataLoader]
    internal static async Task<Dictionary<Guid, ImmutableList<Book>>> GetBooksByAuthorIdAsync(
        IReadOnlyList<Guid> keys,
        TemporalTablesDbContext context,
        CancellationToken cancellationToken)
        => await context.Books
            .Where(b => keys.Contains(b.AuthorId))
            .GroupBy(b => b.AuthorId)
            .ToDictionaryAsync(g => g.Key, g => g.ToImmutableList(), cancellationToken);
}