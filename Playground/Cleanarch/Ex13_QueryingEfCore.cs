using Microsoft.EntityFrameworkCore;

namespace Play.cleanarch;

public static class Ex13_QueryingEfCore
{
    public static void Run()
    {
        using var db = new Infrastructure.AppDbContext();

        var contains19 = db.Books.Where(c => c.Title.Contains("19")).ToList();

        foreach (var item in contains19)
        {
            Console.WriteLine($"items: {item.Title}");
        }

        var bookWithOutInclude = db.Books.Where(b => b.Id == 1);
        foreach (var item in bookWithOutInclude)
        {
            Console.WriteLine($"bookWithOutInclude: {item.Author?.Name ?? "NULL"}");
        }


        var bookWithInclude = db.Books.Include(b => b.Author).Where(b => b.Id == 1);

        Console.WriteLine($"QueryString: {bookWithInclude.ToQueryString()}");

        foreach (var item in bookWithInclude)
        {
            if (item.Author?.Name is not null)
            {
                Console.WriteLine($"bookWithInclude: {item.Author.Name}");
            }
        }


    }
}