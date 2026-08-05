using System.Security.Cryptography;

namespace Play.linq;

public record Product(string Name, decimal Price, int Stock);

public static class Ex02_FilterProject
{
    public static void Run()
    {
        List<Product> products = new()
        {
          new Product("Widget", 9.99m, 50),
          new Product("Gadget", 19.99m, 0),
          new Product("Gizmo", 14.99m, 12)  
        };

        // Todo 1: 
        List<string> names = products.Where(p=> true)
            .Select(p => p.Name).ToList();
        Console.WriteLine($"{string.Join(",", names)}");
        
        // Todo 2: Query syntex
        var inStockNamesQuery = from p in products 
        where p.Stock > 0 select p.Name;

        Console.WriteLine("\nQuery Syntex:");
        Console.WriteLine(string.Join(", ", inStockNamesQuery));

        // Todo 3: Deferred execution
        var inStockProducts = products.Where(p=> p.Stock > 0);
        
        products.Add(new Product("Thingamajig", 2.99m, 8));

        Console.WriteLine("\nDeferred Execution");
        foreach(var product in inStockProducts)
        {
            Console.WriteLine(product.Name);
        }
    }
}