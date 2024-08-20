using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.Services;

public sealed class AuthorService(TemporalTablesDbContext context)
{
    public IQueryable<Author?> GetAuthorById(Guid id) => context.Authors.Where(a => a.Id == id);
    public IQueryable<Author> GetAuthors() => context.Authors;
    
    public async Task CreateAuthorAsync(
        Author author, 
        CancellationToken ct = default)
    {
        context.Authors.Add(author);
        await context.SaveChangesAsync(ct);
    }
    
    public async Task<Author> UpdateAuthorAsync(
        string name, 
        Guid authorId, 
        CancellationToken ct = default)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null)
            throw new ArgumentNullException($"Author with id {authorId} not found");
        
        author.Name = name;
        await context.SaveChangesAsync(ct);
        return author;
    }
}