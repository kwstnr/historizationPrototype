using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.Services.DataLoaders;

internal static class AuthorDataLoader
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<Guid, Author>> GetAuthorByIdAsync(
        IReadOnlyList<Guid> keys,
        TemporalTablesDbContext context,
        CancellationToken cancellationToken)
        => await context.Authors
            .Where(a => keys.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);
}