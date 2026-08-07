namespace Play.linq;

public record Customer(int Id, string Name);
public record Order(int CustomerId, decimal Amount);

public static class Ex06_SetsAndJoins
{
    public static void Run()
    {
        List<string> thisWeekBuyers = new() { "Ana", "Bilal", "Chen" };
        List<string> lastWeekBuyers = new() { "Bilal", "Chen", "Deepa" };

        // TODO 1: names that bought in BOTH weeks — Intersect.
        var intersectNames = thisWeekBuyers.Intersect(lastWeekBuyers);
        Console.WriteLine(string.Join(",", intersectNames));
        Console.WriteLine("\n");


        // TODO 2: names that bought at any point across both weeks, no duplicates — Union.
        var uniqueUnison = thisWeekBuyers.Union(lastWeekBuyers).Distinct();
        Console.WriteLine(string.Join(",", uniqueUnison));
        Console.WriteLine("\n");

        // TODO 3: names that bought this week but NOT last week (new buyers) — Except.
        var boughtThisWeek = thisWeekBuyers.Except(lastWeekBuyers);
        Console.WriteLine(string.Join(",", boughtThisWeek));
        Console.WriteLine("\n");

        List<Customer> customers = new()
        {
            new Customer(1, "Ana"),
            new Customer(2, "Bilal"),
            new Customer(3, "Chen"),
        };

        List<Order> orders = new()
        {
            new Order(1, 50m),
            new Order(2, 30m),
            new Order(1, 20m),
            new Order(4, 99m),   // no matching customer — should NOT appear in the join result
        };

        // TODO 4: Join orders to customers on CustomerId == Id, produce and print
        //         "{customer.Name} paid {order.Amount}" for each matching order.
        //         Confirm the Order with CustomerId 4 is silently dropped (no customer 4 exists).

        var result = orders.Join(
            customers,
            order => order.CustomerId,
            customer=> customer.Id,
            (order, customer)=> $"{customer.Name} paid {order.Amount}"
        );

        foreach(var value in result)
        {
            Console.WriteLine(value);
        }
    }
}
