namespace Play.fun;

public interface IHasScore
{
    int Score {get;}
}

public record Player(string Name, int Score): IHasScore;
public record Product(string Sku, int Score): IHasScore;

public static class Ex15_GenericConstraints
{
    public static T Highest<T>(IEnumerable<T> items) where T: IHasScore{
        int highestScore = int.MinValue;

        foreach(var item in items)
        {
            if(item.Score > highestScore)
            {
                highestScore = item.Score;
            }
        }
        return items.First(i => i.Score == highestScore);
    }

    public static void Run()
    {
        List<Player> players = new()
        {
            new Player("Ana", 70),
            new Player("Bilal", 95),
            new Player("Chenn", 88)
        };

        List<Product> products = new()
        {
            new Product("SKU-1", 12),
            new Product("SKU-2", 40)  
        };

        Player playerWithHighestScore = Highest(players);
        Product productWithHighestScore = Highest(products);


        Console.WriteLine($"Player with highest score: {playerWithHighestScore.Name} ({playerWithHighestScore.Score})");
        Console.WriteLine($"Product with highest score: {productWithHighestScore.Sku} ({productWithHighestScore.Score})");
    }
}