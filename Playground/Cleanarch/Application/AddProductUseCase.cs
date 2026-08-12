using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public record AddProductRequest(int Id, string Name, decimal Price);
public record AddProductResponse(bool Success);

public class AddProductUseCase
{
    private readonly IProductRepository _IProductRepository;

    public AddProductUseCase(IProductRepository productRepository)
    {
        _IProductRepository = productRepository;
    }

    public AddProductResponse Execute(AddProductRequest request)
    {
        var newProduct = new Product(request.Id, request.Name, request.Price);
        _IProductRepository.Add(newProduct);
        return new AddProductResponse(true);
    }
    
}