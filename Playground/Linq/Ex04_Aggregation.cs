namespace Play.linq;

public record Sale(string Product, decimal Price, int Quantity);

public static class Ex04_Aggregation
{
    public static void Run()
    {
        List<Sale> sales = new()
        {
            new Sale("Widget", 9.99m, 5),
            new Sale("Gadget", 19.99m, 2),
            new Sale("Gizmo", 14.99m, 8),
            new Sale("Widget", 9.99m, 3),
        };

        // TODO 1: total revenue = Sum of (Price * Quantity) across all sales.
        var totalRevenue = sales.Sum(p=>p.Price * p.Quantity);
        Console.WriteLine($"Total Revenue: {totalRevenue}");

        // TODO 2: total items sold = Sum of Quantity.
        var totalItemSold = sales.Sum(p=>p.Quantity);
        Console.WriteLine($"Total items sold: {totalItemSold}");

        // TODO 3: count of sales with Quantity > 3, using Count(predicate).
        var soldGreatherThan3 = sales.Count(s=> s.Quantity > 3);
        Console.WriteLine($"Quantities great than 3: {soldGreatherThan3}");

        // TODO 4: average Price across all sales, using Average.
        var avgPrice = sales.Average(s=> s.Price);
        Console.WriteLine($"Average price: {avgPrice}");


        // TODO 5: the cheapest whole Sale record (not just its price), using MinBy.
        var cheapestRecord = sales.MinBy(p=> p.Price);
        Console.WriteLine($"Cheapest whole sale record: {cheapestRecord.Product}: {cheapestRecord.Price}, {cheapestRecord.Quantity}");
        
        // TODO 6: the most expensive whole Sale record, using MaxBy.
        var expensiveRecord = sales.MaxBy(p=> p.Price);
        Console.WriteLine($"expensiveRecord whole sale record: {expensiveRecord.Product}: {expensiveRecord.Price}, {expensiveRecord.Quantity}");

        // TODO 7: recompute total revenue from TODO 1, but with Aggregate instead of
        //         Sum, to see Sum is really just a specialized Aggregate.
        var totalRevenue2 = sales.Aggregate(0m, (sum, p)=> sum+ p.Price * p.Quantity);
        Console.WriteLine($"total revenue: {totalRevenue2}");
    }
}
