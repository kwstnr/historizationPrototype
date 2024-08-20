using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Mutations;

[MutationType]
public static class BookMutations
{
    public static async Task<Book> CreateBookAsync(string title, Guid authorId, DateTimeOffset publishedAt, float price, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.CreateBookAsync(title, authorId, publishedAt, price, cancellationToken);

    public static async Task<Book> UpdateBookTitleAsync(Guid bookId, string title, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.UpdateBookTitleAsync(bookId, title, cancellationToken);

    public static async Task<Book> UpdateBookPriceAsync(Guid bookId, float price, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.UpdateBookPriceAsync(bookId, price, cancellationToken);
}