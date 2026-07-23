namespace Play.fun;

public record Trade(double Price, double Quantity);
public static class All_things
{
    public static double TotalValue(List<Trade> trades)
    {
        double total = 0;

        foreach (var trade in trades)
        {
            double currenttotal = trade.Price * trade.Quantity;
            total += currenttotal;
        }

        return total;
    }

    public static void Run()
    {
        var original = new Trade(20, 5);
        var changed = original with {Price = 40};

        List<Trade> trades = new List<Trade>{
          changed
        };
        var total = TotalValue(trades);
        Console.WriteLine($"Total value: {total}");
    }
}