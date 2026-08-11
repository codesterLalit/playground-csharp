using Microsoft.EntityFrameworkCore;
using Play.cleanarch.Domain;

namespace Play.cleanarch.Infrastructure;

public class AppDbContext : DbContext
{
    // TODO: DbSet<Author> Authors { get; set; }
    // TODO: DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: optionsBuilder.UseSqlite("Data Source=cleanarch.db");
    }
}
