using HotChocolate.Execution.Configuration;

namespace TemporalTables.Extensions;

public static class TemporalTablesGraphQLConventions
{
    public static IRequestExecutorBuilder AddGraphQLConventions(this IRequestExecutorBuilder builder)
    => builder
            .AddFiltering()
            .AddProjections()
            .AddSorting()
            .AddPagingArguments();
}