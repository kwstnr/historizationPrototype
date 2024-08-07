using Microsoft.EntityFrameworkCore;
using TemporalTables.Data;
using TemporalTables.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<TemporalTablesDbContext>(
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services.AddScoped<AuthorService>();

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);