using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types;

[MutationType]
public static class AuthorMutations
{
    public static async Task<Author> CreateAuthorAsync(string name, [Service] AuthorService authorService,
        CancellationToken cancellationToken)
    {
        var author = Author.Create(name);
        await authorService.CreateAuthorAsync(author, cancellationToken);
        return author;
    }
}