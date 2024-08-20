using HotChocolate.Data.Filters;
using TemporalTables.Model;

namespace TemporalTables.Types.FilterInputs;

public abstract class BookFilterInputType : FilterInputType<Book>
{
    protected override void Configure(IFilterInputTypeDescriptor<Book> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(b => b.Title).Type<SearchStringOperationFilterInputType>();
    }
}