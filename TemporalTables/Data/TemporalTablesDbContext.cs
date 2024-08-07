using Microsoft.EntityFrameworkCore;
using TemporalTables.Model;

namespace TemporalTables.Data;

public class TemporalTablesDbContext(DbContextOptions<TemporalTablesDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}