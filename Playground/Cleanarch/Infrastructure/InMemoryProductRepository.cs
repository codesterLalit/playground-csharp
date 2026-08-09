using Play.cleanarch.Domain;
using Play.cleanarch.Application;

namespace Play.cleanarch.Infrastructure;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

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