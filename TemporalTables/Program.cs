using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
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
    .AddTypes()
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);