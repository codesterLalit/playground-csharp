namespace Play.cleanarch;

using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Infrastructure;

public static class Ex07_UseCasePattern
{
    public static void Run()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<AddProductUseCase>();
        services.AddSingleton<GetProductUseCase>();

        using var provider = services.BuildServiceProvider();

        var addProductService = provider.GetRequiredService<AddProductUseCase>();
        var getProductService = provider.GetRequiredService<GetProductUseCase>();

        // TODO: 
        var newproduct1 = new AddProductRequest(320, "Facewash", 110);
        var newproduct2 = new AddProductRequest(310, "Moisturiser", 120);
        var newproduct3 = new AddProductRequest(300, "Sunscreen", 150);
        addProductService.Execute(newproduct1);
        addProductService.Execute(newproduct2);
        addProductService.Execute(newproduct3);

        // TODO: 
        var getProductRequest = new GetProductRequest(320);
        var fetchedProduct = getProductService.Execute(getProductRequest);
        Console.WriteLine($"Fetched product: {fetchedProduct.Product?.Name}");
    }
}