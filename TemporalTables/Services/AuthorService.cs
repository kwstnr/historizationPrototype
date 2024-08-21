using Microsoft.EntityFrameworkCore;
using TemporalTables.Builder;
using TemporalTables.Data;
using TemporalTables.DataLoaders;
using TemporalTables.Model;

namespace TemporalTables.Services;

public sealed class AuthorService(TemporalTablesDbContext context, AuthorByIdDataLoader authorByIdDataLoader)
{
    public async Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken) => await authorByIdDataLoader.LoadAsync(id, cancellationToken);
    public IQueryable<Author> GetAuthors() => context.Authors;
    
    public async Task<Author> CreateAuthorAsync(
        string name, 
        CancellationToken ct = default)
    {
        var author = new AuthorBuilder().Name(name).Build();
        context.Authors.Add(author);
        await context.SaveChangesAsync(ct);
        return author;
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