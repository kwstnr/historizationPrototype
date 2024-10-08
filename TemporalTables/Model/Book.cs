using System.ComponentModel.DataAnnotations;

namespace TemporalTables.Model;

public sealed class Book
{
    [Key]
    public Guid Id { get; init; }
    public string Title { get; set; }
    public Author Author { get; internal set; }
    public Guid AuthorId { get; internal set; }
    public DateTimeOffset PublishedAt { get; set; }
    public float Price { get; set; }

    internal Book()
    {
    }
};