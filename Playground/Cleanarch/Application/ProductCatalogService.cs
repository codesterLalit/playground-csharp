using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public class ProductCatalogService
{
    private readonly IProductRepository _iProductRespository;

    public ProductCatalogService(IProductRepository productRepository)
    {
        _iProductRespository = productRepository;
    }

    public void AddProduct(int id, string name, decimal price)
    {
        Product product = new (id, name, price);
        _iProductRespository.Add(product);
    }

    public Product GetProduct(int id)
    {
        var product = _iProductRespository.GetById(id);
        return product;
    }
}