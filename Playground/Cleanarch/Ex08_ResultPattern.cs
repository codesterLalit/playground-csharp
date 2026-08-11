using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

// Lesson: exceptions should be for truly unexpected failures (a dropped DB connection, a bug). An expected,
// everyday outcome like "product not found" is part of the normal contract of a use case, not an exception.
// Result<T> makes that outcome an explicit return value instead of a nullable field or a thrown exception —
// the caller is forced to check IsSuccess before touching Value, rather than being able to forget a null check
// and blow up at runtime (the exact bug you saw for real back in Exercise 5/6's GetById).

public static class Ex08_ResultPattern
{
    public static void Run()
    {
        var services = new ServiceCollection();

        // TODO: register IProductRepository -> InMemoryProductRepository, AddProductUseCase (from Exercise 7), FindProductUseCase

        using var provider = services.BuildServiceProvider();

        // TODO: resolve AddProductUseCase, add one product
        // TODO: resolve FindProductUseCase, Execute for that product's id
        //       -> check result.IsSuccess, print result.Value
        // TODO: Execute FindProductUseCase again for an id that doesn't exist
        //       -> check result.IsSuccess, print result.Error
        //
        // Notice: no null checks, no try/catch anywhere in this method — Result<T> forces both paths
        // to be handled explicitly at the call site.
    }
}
