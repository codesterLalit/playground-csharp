namespace Play.cleanarch;

using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Domain;
using Play.cleanarch.Infrastructure;

public static class Ex06_Layering
{
    public static void Run()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<ProductCatalogService>();

        var provider = services.BuildServiceProvider();
        var customerService = provider.GetRequiredService<ProductCatalogService>();

        customerService.AddProduct(320, "Iphone 17", 320m);
        var product = customerService.GetProduct(320);
        Console.WriteLine($"New Product: {product.Name}");
    }
}