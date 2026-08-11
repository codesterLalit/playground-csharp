using Microsoft.EntityFrameworkCore;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

// Lesson: db.Books.Where(...) is the same LINQ you already know from the Linq/ track, but it now returns
// IQueryable<Book> instead of IEnumerable<Book> — EF translates the expression tree into SQL and nothing
// hits the database until you enumerate it (ToList(), FirstOrDefault(), foreach, etc). Same deferred
// execution idea as Ex02_FilterProject, just deferred all the way out to a real SQL query.
//
// By default, navigating book.Author gives you null even if the row has a matching AuthorId — EF doesn't
// silently join related tables for you. .Include(b => b.Author) tells it to eager-load that relationship
// as part of the same query.

public static class Ex13_QueryingEfCore
{
    public static void Run()
    {
        // TODO: using var db = new AppDbContext();
        // TODO: seed a couple Authors, each with a couple Books, SaveChanges()

        // TODO: query books whose Title contains some substring using .Where(...), materialize with .ToList(), print titles

        // TODO: query one book by id using .Include(b => b.Author), then print book.Title and book.Author.Name
        //       — try it WITHOUT Include first and confirm Author really does come back null

        // TODO: pick one of your queries and print query.ToQueryString() before enumerating it,
        //       to see the actual SQL EF generated from your LINQ
    }
}
