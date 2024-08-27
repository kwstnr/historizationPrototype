using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Queries;

[QueryType]
public static class BookQueries
{
    // [NodeResolver]
    // public static async Task<Book?> GetBookByIdAsync(Guid id,
    //     [Service] BookService bookService,
    //     CancellationToken cancellationToken)
    //     => await bookService.GetBookByIdAsync(id, cancellationToken);
    
    
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Book> GetBooks(
        [Service] BookService bookService)
        => bookService.GetBooks();
}