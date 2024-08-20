using HotChocolate.Data.Filters;
using TemporalTables.Model;

namespace TemporalTables.Types.FilterInputs;

public class AuthorFilterInputType : FilterInputType<Author>
{
    protected override void Configure(IFilterInputTypeDescriptor<Author> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(a => a.Name).Type<SearchStringOperationFilterInputType>();
    }
}