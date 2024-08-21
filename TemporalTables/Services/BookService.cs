using Microsoft.EntityFrameworkCore;
using TemporalTables.Builder;
using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.Services;

public sealed class BookService(TemporalTablesDbContext context)
{
    public async Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken) => await context.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public IQueryable<Book> GetBooks() => context.Books;

    public async Task<IReadOnlyList<Book>>
        GetBooksByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken) =>
        await context.Books.Where(b => b.AuthorId == authorId).ToListAsync(cancellationToken);
    
    public async Task<Book> CreateBookAsync(string title, Guid authorId, DateTimeOffset publishedAt, float price, CancellationToken ct)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null)
            throw new ArgumentNullException($"Author with id {authorId} not found");
        
        var book = new BookBuilder()
            .Title(title)
            .Author(author)
            .PublishedAt(publishedAt)
            .Price(price)
            .Build();
        context.Books.Add(book);
        await context.SaveChangesAsync(ct);
        return book;
    }
    
    public async Task<Book> UpdateBookTitleAsync(Guid bookId, string title, CancellationToken ct)
    {
        var book = await context.Books.FindAsync(bookId);
        if (book == null)
            throw new ArgumentNullException($"Book with id {bookId} not found");
        
        book.Title = title;
        await context.SaveChangesAsync(ct);
        return book;
    }

    public async Task<Book> UpdateBookPriceAsync(Guid bookId, float price, CancellationToken ct)
    {
        var book = await context.Books.FindAsync(bookId);
        if (book == null)
            throw new ArgumentNullException($"Book with id {bookId} not found");
        
        book.Price = price;
        await context.SaveChangesAsync(ct);
        return book;
    }

    public async Task<bool> DeleteBookAsync(Guid bookId, CancellationToken ct)
    {
        var book = await context.Books.FindAsync(bookId);
        if (book == null)
            return false;
        
        context.Books.Remove(book);
        await context.SaveChangesAsync(ct);
        return true;
    }
}