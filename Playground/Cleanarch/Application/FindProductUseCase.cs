using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public record FindProductRequest(int Id);

public class FindProductUseCase
{
    // TODO: constructor takes IProductRepository
    // TODO: Execute(FindProductRequest request) -> Result<Product>
    //       look up the product via the repository
    //       - not found -> Result<Product>.Failure($"Product {request.Id} not found")
    //       - found -> Result<Product>.Success(product)
}
