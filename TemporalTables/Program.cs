using HotChocolate.Data.Filters;
using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
using TemporalTables.Extensions;
using TemporalTables.Services;
using TemporalTables.Types.FilterInputs;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<TemporalTablesDbContext>(
        o => o.UseSqlServer(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddScoped<AuthorService>()
    .AddScoped<BookService>();

builder.Services
    .AddGraphQLServer()
    .AddTypes()
    .AddType<BookFilterInputType>()
    .AddType<AuthorFilterInputType>()
    .AddGraphQLConventions();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);