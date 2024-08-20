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
    public static IQueryable<Book> GetBooks([Service] BookService bookService) => bookService.GetBooks();
}