using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public interface IProductRepository
{
    public void Add(Product product);
    public Product? GetById(int id);
    public IEnumerable<Product> GetAll();
}