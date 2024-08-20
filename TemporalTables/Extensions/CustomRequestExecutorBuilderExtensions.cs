using HotChocolate.Execution.Configuration;

namespace TemporalTables.Extensions;

public static class CustomRequestExecutorBuilderExtensions
{
    public static IRequestExecutorBuilder AddGraphQLConventions(this IRequestExecutorBuilder builder)
    => builder
            .AddFiltering()
            .AddProjections()
            .AddSorting();
}