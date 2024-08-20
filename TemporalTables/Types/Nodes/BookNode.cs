using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Nodes;

[ObjectType<Book>]
public static partial class BookNode
{
    static partial void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Ignore(b => b.AuthorId);
    }
    
    public static async Task<Author?> GetAuthorAsync(
        [Parent] Book book, 
        AuthorService authorService,
        CancellationToken cancellationToken)
        => await authorService.GetAuthorByIdAsync(book.AuthorId, cancellationToken);
}