using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

// Lesson: Microsoft.EntityFrameworkCore.Sqlite and .Design packages are already added to Playground.csproj.
// A DbContext is your entry point to a real database — DbSet<T> properties map to tables, and the context
// tracks changes you make so SaveChanges() knows what SQL to run. For now we skip formal migrations
// (SaveChanges/EnsureCreated only) — Exercise 12 covers migrations properly.

public static class Ex11_DbContextBasics
{
    public static void Run()
    {
        // TODO: using var db = new AppDbContext();
        // TODO: db.Database.EnsureCreated();
        //       creates the sqlite file + schema directly from your DbSet properties, no migration needed yet

        // TODO: add an Author, then a Book referencing that Author's id, via db.Authors.Add(...)/db.Books.Add(...)
        // TODO: db.SaveChanges();

        // TODO: query the book back: db.Books.FirstOrDefault(b => b.Id == ...), print its Title
    }
}
