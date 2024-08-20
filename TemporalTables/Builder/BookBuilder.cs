using TemporalTables.Model;

namespace TemporalTables.Builder;

public class BookBuilder
{
    private string _title;
    private Author _author;
    private Guid _authorId;

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

    public Book Build()
    {
        return new Book
        {
            Title = _title,
            Author = _author,
            AuthorId = _authorId
        };
    }
}