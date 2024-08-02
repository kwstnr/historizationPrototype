using Microsoft.EntityFrameworkCore;
using TemporalTables.Model;

namespace TemporalTables.Data;

public class TemporalTablesDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Database=TemporalTables;Username=myuser;Password=mypassword");
    }
}