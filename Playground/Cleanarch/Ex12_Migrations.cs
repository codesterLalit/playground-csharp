namespace Play.cleanarch;

// Lesson: EnsureCreated() (Exercise 11) is fine for a throwaway demo, but it can't evolve a schema — if you
// add a property later, it won't touch an already-created database. Migrations are versioned, incremental
// schema changes: each one records exactly what changed, so the database can be brought forward (or back)
// step by step, in production, without dropping data.
//
// SETUP (run from the Playground/ folder before this exercise):
//   dotnet tool install --global dotnet-ef        (skip if already installed — check with: dotnet ef --version)
//   dotnet ef migrations add InitialCreate
//   dotnet ef database update
//
// NOTE: delete cleanarch.db (created by Exercise 11's EnsureCreated) first if it still exists —
// EnsureCreated and migrations don't mix cleanly against the same database file, since EnsureCreated
// doesn't record any migration history.

public static class Ex12_Migrations
{
    public static void Run()
    {
        // TODO: using var db = new Infrastructure.AppDbContext();
        // TODO: db.Database.Migrate();  <- applies any pending migrations, replaces EnsureCreated()

        // TODO: add another Author/Book, SaveChanges(), query it back and print it — proving the migrated
        //       schema works exactly like Exercise 11's did

        // Then, to see a schema change in action:
        //   1. Add a property to Book (e.g. an int Year)
        //   2. dotnet ef migrations add AddBookYear
        //   3. dotnet ef database update
        //   4. confirm the new column round-trips through a Book you add and query back
    }
}
