using HotChocolate.Pagination;
using HotChocolate.Types.Pagination;
using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Queries;

[QueryType]
public static class BookQueries
{
    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Book?> GetBookById(Guid id,
        [Service] BookService bookService)
        => bookService.GetBookById(id);

    [UsePaging]
    [UseProjection]
    public static async Task<Connection<Book>> GetBooksCursorBased(
        PagingArguments pagingArguments,
        [Service] BookService bookService,
        CancellationToken cancellationToken) 
        => await bookService.GetBooks(pagingArguments , cancellationToken).ToConnectionAsync();
    
    public static async Task<IQueryable<Book>> GetBooks(
        [Service] BookService bookService)
        => bookService.GetBooks();
}