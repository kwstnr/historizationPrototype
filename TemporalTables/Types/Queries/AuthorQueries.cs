using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Queries;

[QueryType]
public static class AuthorQueries
{
    [UseFirstOrDefault]
    public static IQueryable<Author?> GetAuthorById(Guid id, [Service] AuthorService authorService) =>
        authorService.GetAuthorById(id);
}