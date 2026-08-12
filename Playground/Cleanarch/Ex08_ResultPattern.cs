using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Domain;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

public static class Ex08_ResultPattern
{
    public static void Run()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<AddProductUseCase>();
        services.AddSingleton<FindProductUseCase>();

        using var provider = services.BuildServiceProvider();

        var addProductUseCaseProvider = provider.GetRequiredService<AddProductUseCase>();
        var findProductUseCaseProvider = provider.GetRequiredService<FindProductUseCase>();

        // new product
        var newProduct = new AddProductRequest(323, "PlayStation", 560);
        addProductUseCaseProvider.Execute(newProduct);

        Result<Product> result1 = findProductUseCaseProvider.Execute(new FindProductRequest(323));
        Console.WriteLine($"isSuccess: {result1.IsSuccess}, value: {result1.Value}");

        Result<Product> result2 = findProductUseCaseProvider.Execute(new FindProductRequest(322));
        Console.WriteLine($"isSuccess: {result2.IsSuccess}, value: {result2.Value}, Error: {result2.Error}");
        
         
    }
}