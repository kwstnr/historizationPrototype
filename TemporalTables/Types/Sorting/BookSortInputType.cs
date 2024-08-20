using HotChocolate.Data.Sorting;
using TemporalTables.Model;

namespace TemporalTables.Types.Sorting;

public class BookSortInputType : SortInputType<Book>
{
    protected override void Configure(ISortInputTypeDescriptor<Book> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(b => b.Title);
        descriptor.Field(b => b.PublishedAt);
        descriptor.Field(b => b.Price);
    }
}