using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Mutations;

[MutationType]
public static class BookMutations
{
    public static async Task<Book> CreateBookAsync(string title, Guid authorId, [Service] BookService bookService,
        CancellationToken cancellationToken)
        => await bookService.CreateBookAsync(title, authorId, cancellationToken);
}