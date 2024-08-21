using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Nodes;

[ObjectType<Author>]
public static partial class AuthorNode
{
    public static async Task<IReadOnlyList<Book>> GetBooksAsync(
        [Parent] Author author,
        BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.GetBooksByAuthorIdAsync(author.Id, cancellationToken);
}