using Play.cleanarch.Application;
using Play.cleanarch.Domain;

namespace Play.cleanarch;

public class FakeProductRepository: IProductRepository
{
    private readonly List<Product> _products = new List<Product>{
        new Product(1, "Pen", 20),
        new Product(2, "Notebook", 100),
        new Product(3, "Bag", 1500),
        new Product(4, "Dress", 600),
        new Product(5, "Book", 4500)
};

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public Product? GetById(int id)
    {
        var product = _products.FirstOrDefault(c=> c.Id == id);
        return product; 
    }

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }
}

public static class Ex09_TestingWithFakes
{
    public static void Run()
    {
        TestFindProduct_WhenExists_ReturnsSuccess();
        TestFindProduct_WhenMissing_ReturnsFailure();
    }

    public static void TestFindProduct_WhenExists_ReturnsSuccess()
    {
        var fake  = new FakeProductRepository();
        var useCase = new FindProductUseCase(fake);
        Result<Product> product = useCase.Execute(new FindProductRequest(1));
        Console.WriteLine($"IsSuccess: {product.IsSuccess}");
        if (product.IsSuccess is true)
        {
            Console.WriteLine($"Pass");
        } else
        {
            Console.WriteLine($"Fail: {product.Error}");
        }
    }

    public static void TestFindProduct_WhenMissing_ReturnsFailure()
    {
        var fake  = new FakeProductRepository();
        var useCase = new FindProductUseCase(fake);
        Result<Product> product = useCase.Execute(new FindProductRequest(120));
        Console.WriteLine($"IsSuccess: {product.IsSuccess}");
        if (product.IsSuccess is true)
        {
            Console.WriteLine($"Pass");
        } else
        {
            Console.WriteLine($"Fail: {product.Error}");
        }
    }
}