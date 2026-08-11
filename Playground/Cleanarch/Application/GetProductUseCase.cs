using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public record GetProductRequest(int Id);
public record GetProductResponse(Product? Product);

public class GetProductUseCase
{
    // TODO: constructor takes IProductRepository
    // TODO: Execute(GetProductRequest request) -> GetProductResponse
    //       looks up the product via the repository, wraps it in the response (Product may be null)
}
