using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public record GetProductRequest(int Id);
public record GetProductResponse(Product? Product);

public class GetProductUseCase
{
    private readonly IProductRepository _IProductRepository;

    public GetProductUseCase(IProductRepository productRepository)
    {
        _IProductRepository = productRepository;
    }

    public GetProductResponse Execute(GetProductRequest request)
    {
        Product? product = _IProductRepository.GetById(request.Id);
        return new GetProductResponse(product);
    }
}