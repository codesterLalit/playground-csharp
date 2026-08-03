namespace Play.delegates;


public class PriceTicker
{
    public event EventHandler<decimal>? PriceChanged;

    private decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            PriceChanged?.Invoke(this, value);
        }
    }
}

public static class Ex04_Events
{
    public static void Run()
    {
        var ticker = new PriceTicker();
        ticker.PriceChanged += (sender, price) =>
        {
            Console.WriteLine($"Price: {price}");
        };

        ticker.PriceChanged += (sender, price) =>
        {
            if (price > 100)
            {
                Console.WriteLine($"ALERT! when the new price is above 100.");
            }
        };

        ticker.Price = 95m;
        ticker.Price = 120m;
    }
}