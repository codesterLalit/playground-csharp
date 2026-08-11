using Play.cleanarch.Domain;

namespace Play.cleanarch.Application;

public record AddProductRequest(int Id, string Name, decimal Price);
public record AddProductResponse(bool Success);

public class AddProductUseCase
{
    // TODO: constructor takes IProductRepository
    // TODO: Execute(AddProductRequest request) -> AddProductResponse
    //       builds a Product from the request, adds it via the repository, returns success
}
