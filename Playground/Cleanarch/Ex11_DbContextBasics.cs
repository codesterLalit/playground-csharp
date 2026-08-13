using Play.cleanarch.Domain;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

public static class Ex11_DbContextBasics
{
    public static void Run()
    {
        using var db = new AppDbContext();
        // db.Database.EnsureCreated();
        try
        {
            db.Add(new Author(1, "Jk Rowling"));
            db.Add(new Book(1, "Harry Potter", 1, 1992));
            db.SaveChanges();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Db Already created.");
        }

        Book? book = db.Books.FirstOrDefault(b => b.Id == 1);
        if (book is not null)
        {
            Console.WriteLine($"Book: {book.Title}");
        }
    }
}