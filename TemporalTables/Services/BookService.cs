using TemporalTables.Data;
using TemporalTables.Model;

namespace TemporalTables.Services;

public sealed class BookService(TemporalTablesDbContext context)
{
    
    public async Task<Book> CreateBookAsync(string title, Guid authorId, CancellationToken ct)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null)
            throw new ArgumentNullException($"Author with id {authorId} not found");
        
        var book = Book.Create(title, author);
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
    
    public IQueryable<Book?> GetBookById(Guid id)
    {
        return context.Books.Where(b => b.Id == id);
    }
}