using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.DataLoaders;

public class AuthorByIdDataLoader(IServiceProvider serviceProvider, IBatchScheduler batchScheduler, DataLoaderOptions options)
    : BatchDataLoader<Guid, Author>(batchScheduler, options)
{
    protected override async Task<IReadOnlyDictionary<Guid, Author>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        await using var context = serviceProvider.GetRequiredService<TemporalTablesDbContext>();
        return await context.Authors.Where(a => keys.Contains(a.Id)).ToDictionaryAsync(a => a.Id, cancellationToken);
    }
}