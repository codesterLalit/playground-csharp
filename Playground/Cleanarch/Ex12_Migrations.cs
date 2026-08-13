using Microsoft.EntityFrameworkCore;
using Play.cleanarch.Domain;

namespace Play.cleanarch;

public static class Ex12_Migrations
{
    public static void Run()
    {
        using var db = new Infrastructure.AppDbContext();
        db.Database.Migrate();

        db.Add(new Author(2, "George Orwell"));
        db.Add(new Book(2, "1984", 2, 1949));
        db.SaveChanges();

        Book? book = db.Books.FirstOrDefault(b => b.Id == 1);
        if (book is not null)
        {
            Console.WriteLine($"Book: {book.Title}, Year: {book.Year}");
        }
    }
}
