using Play.cleanarch.Application;
using Play.cleanarch.Domain;

namespace Play.cleanarch;

// Lesson: this is the actual payoff of everything from Exercise 1 onward. Because FindProductUseCase depends
// on IProductRepository (an abstraction, not InMemoryProductRepository directly), you can test it completely
// in isolation by handing it a purpose-built fake — no DI container, no real infrastructure, entirely
// deterministic. A real project would use xUnit/NUnit with [Fact]-attributed methods and an Assert library
// instead of hand-rolled PASS/FAIL prints, but the core idea — construct the thing under test directly,
// with a fake dependency, and no container in sight — is identical.

public class FakeProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

    public void Add(Product product)
    {
        // TODO: add to _products
        throw new NotImplementedException();
    }

    public Product? GetById(int id)
    {
        // TODO: find in _products by id
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAll()
    {
        // TODO: return _products
        throw new NotImplementedException();
    }
}

public static class Ex09_TestingWithFakes
{
    public static void Run()
    {
        TestFindProduct_WhenExists_ReturnsSuccess();
        TestFindProduct_WhenMissing_ReturnsFailure();
    }

    private static void TestFindProduct_WhenExists_ReturnsSuccess()
    {
        // TODO: var fake = new FakeProductRepository(); seed it with one product via Add
        // TODO: var useCase = new FindProductUseCase(fake);  <- no container, just 'new'
        // TODO: Execute for that product's id
        // TODO: check result.IsSuccess is true AND result.Value matches what you seeded
        // TODO: Console.WriteLine("PASS" or "FAIL: <what went wrong>")
    }

    private static void TestFindProduct_WhenMissing_ReturnsFailure()
    {
        // TODO: var fake = new FakeProductRepository();  <- fresh, empty, nothing seeded
        // TODO: var useCase = new FindProductUseCase(fake);
        // TODO: Execute for any id
        // TODO: check result.IsSuccess is false AND result.Error is not null/empty
        // TODO: Console.WriteLine("PASS" or "FAIL: <what went wrong>")
    }
}
