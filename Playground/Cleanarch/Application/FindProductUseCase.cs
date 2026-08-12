using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public record FindProductRequest(int Id);

public class FindProductUseCase
{
    private readonly IProductRepository _IProductRepository;
    public FindProductUseCase(IProductRepository productRepository)
    {
        _IProductRepository = productRepository;
    }

    public Result<Product> Execute(FindProductRequest request)
    {
        Product? resultProduct = _IProductRepository.GetById(request.Id);
        if (resultProduct is null)
        {
            return Result<Product>.Failure($"Product {request.Id} not found");
        }
        return Result<Product>.Success(resultProduct);
    }
}