using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Mutations;

[MutationType]
public static class AuthorMutations
{
    public static async Task<Author> CreateAuthorAsync(string name, [Service] AuthorService authorService,
        CancellationToken cancellationToken)
        => await authorService.CreateAuthorAsync(name, cancellationToken);
    
    public static async Task<Author> UpdateAuthorAsync(Guid authorId, string name, [Service] AuthorService authorService,
        CancellationToken cancellationToken)
        => await authorService.UpdateAuthorAsync(name, authorId, cancellationToken);
}