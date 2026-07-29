namespace Play.fun;

public record BookRecord(string Title, string Author, int Year);
public record MutableBook(string Title, string Author)
{
    public int Year {get; set;}
}

public static class Ex02_WithExpressions
{
    public static void Run()
    {
        var original = new BookRecord("Science", "Nepali", 2000);
        var reprint = original with {Year = 2002};

        Console.WriteLine(ReferenceEquals(original, reprint)); // result - false

        // original.Author = "Lalit"; // not able to change because we are immutable
        var thirdRecord = new MutableBook("Mutablebook", "Hero") {Year = 1990};
        thirdRecord.Year = 2002; // able to change because it was use as get; set; instead of direct record.
    }
}