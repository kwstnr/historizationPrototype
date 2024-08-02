using TemporalTables.Model;

namespace TemporalTables.Types;

[QueryType]
public static class Query
{
    public static Book GetBook()
        => Book.Create("C# in depth.", Author.Create("Jon Skeet"));
}