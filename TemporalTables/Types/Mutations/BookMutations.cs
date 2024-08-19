using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Mutations;

[MutationType]
public static class BookMutations
{
    public static async Task<Book> CreateBookAsync(string title, Guid authorId, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.CreateBookAsync(title, authorId, cancellationToken);
    
    public static async Task<Book> UpdateBookTitleAsync(Guid bookId, string title, [Service] BookService bookService, CancellationToken cancellationToken)
    {
        var book = await bookService.UpdateBookTitleAsync(bookId, title, cancellationToken);
        return book;
    }
}