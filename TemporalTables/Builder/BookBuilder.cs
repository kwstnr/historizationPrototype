using TemporalTables.Model;

namespace TemporalTables.Builder;

public class BookBuilder
{
    private string _title;
    private Author _author;
    private Guid _authorId;
    private DateTimeOffset _publishedAt;
    private float _price;

    public BookBuilder Title(string title)
    {
        _title = title;
        return this;
    }

    public BookBuilder Author(Author author)
    {
        _author = author;
        return this;
    }

    public BookBuilder AuthorId(Guid authorId)
    {
        _authorId = authorId;
        return this;
    }
    
    public BookBuilder PublishedAt(DateTimeOffset publishedAt)
    {
        _publishedAt = publishedAt;
        return this;
    }
    
    public BookBuilder Price(float price)
    {
        _price = price;
        return this;
    }

    public Book Build()
    {
        return new Book
        {
            Title = _title,
            Author = _author,
            AuthorId = _authorId,
            PublishedAt = _publishedAt,
            Price = _price
        };
    }
}