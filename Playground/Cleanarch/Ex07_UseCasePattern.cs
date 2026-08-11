using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

// Lesson: instead of one service class with several methods (ProductCatalogService), give each business
// operation its own class with a single Execute(request) -> response entry point. Explicit request/response
// records make the contract obvious, and a narrow class with one job is trivial to test in isolation
// (see Exercise 9) compared to a service class juggling several unrelated methods and dependencies.

public static class Ex07_UseCasePattern
{
    public static void Run()
    {
        var services = new ServiceCollection();

        // TODO: register IProductRepository -> InMemoryProductRepository, AddProductUseCase, GetProductUseCase

        using var provider = services.BuildServiceProvider();

        // TODO: resolve AddProductUseCase, execute it with a request, print the response
        // TODO: resolve GetProductUseCase, execute it for the same id, print the response
        //       (including whether Product came back null or not)
    }
}
