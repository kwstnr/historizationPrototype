using TemporalTables.Model;
using TemporalTables.Services;
using TemporalTables.Types.Sorting;

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
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Book> GetBooks([Service] BookService bookService) => bookService.GetBooks();
}