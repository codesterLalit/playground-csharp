namespace Play.fun;

public record BookRecords(string Title, string Author, int Year);

public class BookClass
{
    public string Title {get; init;}
    public string Author {get; init;}
    public int Year {get; init;}
}

public static class Ex01_Records
{
    public static void Run()
    {
        var bookRecord1 = new BookRecords("GOT", "George R. Martin", 1990);
        var bookRecord2 = new BookRecords("GOT", "George R. Martin", 1990);

        if(bookRecord1 == bookRecord2)
        {
            Console.WriteLine("records - Same with ===");
        }

        if (bookRecord1.Equals(bookRecord2))
        {
            Console.WriteLine("records - Same with equals");
        }

        // result = got both answer

        var bookClass1 = new BookClass
        {
            Title = "Game of thrones", 
            Author = "George R. Martin", 
            Year = 1990
        };

        var bookClass2 = new BookClass
        {
            Title = "GOT", 
            Author = "George R. Martin", 
            Year = 1990
        };

        if(bookClass1 == bookClass2)
        {
            Console.WriteLine("class - Same with  == ");
        }

        if(bookClass1.Equals(bookClass2))
        {
            Console.WriteLine("class - Same with  == ");
        }
    }
}
