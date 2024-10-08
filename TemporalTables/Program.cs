using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
using TemporalTables.Extensions;
using TemporalTables.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<TemporalTablesDbContext>(
        o => o.UseSqlServer(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddScoped<AuthorService>()
    .AddScoped<BookService>();

builder.Services
    .AddGraphQLServer()
    .AddTemporalTables()
    .AddGraphQLConventions();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);