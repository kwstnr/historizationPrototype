using System.Transactions;

namespace TemporalTables.Model;

public sealed class Author
{
    public string Name { get; private set; }
    
    private Author()
    {
    }
    
    private Author(string name)
    {
        Name = name;
    }
    
    public static Author Create(string name)
    {
        return new Author(name);
    }
}