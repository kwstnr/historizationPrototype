using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Queries;

[QueryType]
public static class AuthorQueries
{
    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Author?> GetAuthorById(Guid id, [Service] AuthorService authorService) =>
        authorService.GetAuthorById(id);
    
    [UsePaging]
    [UseProjection]
    public static IQueryable<Author> GetAuthors([Service] AuthorService authorService) =>
        authorService.GetAuthors();
}