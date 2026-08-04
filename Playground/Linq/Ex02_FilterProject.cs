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
        
        // Todo 2:
        products.Where(p=> true)
        .Select(p=> Console.WriteLine(p.Name));
    }
}