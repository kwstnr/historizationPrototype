using TemporalTables.Model;
using TemporalTables.Services;

namespace TemporalTables.Types.Queries;

[QueryType]
public static class AuthorQueries
{
    public static async Task<Author?> GetAuthorById(Guid id, [Service] AuthorService authorService,
        CancellationToken cancellationToken) =>
        await authorService.GetAuthorByIdAsync(id, cancellationToken);
    
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Author> GetAuthors([Service] AuthorService authorService) =>
        authorService.GetAuthors();
}