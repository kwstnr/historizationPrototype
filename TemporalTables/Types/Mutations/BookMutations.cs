using TemporalTables.Model;
using TemporalTables.Services;
using TemporalTables.Types.Nodes;

namespace TemporalTables.Types.Mutations;

[MutationType]
public static class BookMutations
{
    public static async Task<Book> CreateBookAsync(string title, Guid authorId, DateTimeOffset publishedAt, float price, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.CreateBookAsync(title, authorId, publishedAt, price, cancellationToken);

    public static async Task<Book> UpdateBookTitleAsync(Guid id, string title, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.UpdateBookTitleAsync(id, title, cancellationToken);

    public static async Task<Book> UpdateBookPriceAsync(Guid id, float price, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.UpdateBookPriceAsync(id, price, cancellationToken);

    public static async Task<DeletionResponse> DeleteBookAsync(Guid id, [Service] BookService bookService,
        CancellationToken cancellationToken)
    {
        var success = await bookService.DeleteBookAsync(id, cancellationToken);
        return new DeletionResponse
        {
            Success = success,
            Message = success ? "Book deleted successfully" : $"Book with id {id} not found"
        };
    }
}