using Microsoft.EntityFrameworkCore;
using Play.cleanarch.Domain;

namespace Play.cleanarch.Infrastructure;

public class AppDbContext: DbContext
{
    public DbSet<Author> Authors {get; set;}
    public DbSet<Book> Books {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=cleanarch;Username=postgres;Password=devpassword");
    }
}