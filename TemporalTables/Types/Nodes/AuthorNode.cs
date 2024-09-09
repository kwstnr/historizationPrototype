using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Nodes;

[ObjectType<Author>]
public static partial class AuthorNode
{
    [UsePaging]
    public static async Task<IQueryable<Book>> GetBooksAsync(
        [Parent] Author author,
        BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.GetBooksByAuthorId(author.Id, cancellationToken);
    
    [NodeResolver]
    public static async Task<Author?> GetAuthorByIdAsync(Guid id,
        [Service] AuthorService authorService,
        CancellationToken cancellationToken)
        => await authorService.GetAuthorByIdAsync(id, cancellationToken);
}