using TemporalTables.Model;

namespace TemporalTables.Builder;

public class AuthorBuilder
{
    private string _name;

    public AuthorBuilder Name(string name)
    {
        _name = name;
        return this;
    }

    public Author Build()
    {
        return new Author
        {
            Name = _name
        };
    }
}