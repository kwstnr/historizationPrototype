using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.Services;

public sealed class AuthorService(TemporalTablesDbContext context)
{
    public async Task CreateAuthorAsync(
        Author author, 
        CancellationToken ct = default)
    {
        context.Authors.Add(author);
        await context.SaveChangesAsync(ct);
    }
}