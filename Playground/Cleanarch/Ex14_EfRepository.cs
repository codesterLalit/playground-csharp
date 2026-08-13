using Play.cleanarch.Application;
using Play.cleanarch.Domain;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

public static class Ex14_EfRepository
{
    public static void Run()
    {
        using var db = new AppDbContext();
        var repository = new EfBookRepository(db);

        Book book1 = new Book(5, "Atlas Shrugged", 2, 1945);
        repository.Add(book1);

        var fetchedBook = repository.GetById(5);
        if (fetchedBook is not null && fetchedBook.Author is not null)
        {
            Console.WriteLine($"Title: {fetchedBook.Title}, Year: {fetchedBook.Year}, Author: {fetchedBook.Author?.Name}");
        }
    }
}