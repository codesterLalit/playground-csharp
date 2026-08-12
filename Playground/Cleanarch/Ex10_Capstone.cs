using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

public static class Ex10_Capstone
{
    public static void Run()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        builder.Services.AddSingleton<FindProductUseCase>();
        builder.Services.AddSingleton<AddProductUseCase>();
        

        var app = builder.Build();

        app.MapPost("/products", (AddProductRequest request, AddProductUseCase useCase) =>
        {
           return useCase.Execute(request); 
        });

        app.MapGet("/products/{id}", (int id, FindProductUseCase useCase) =>
        {
            var result = useCase.Execute(new FindProductRequest(id));
            return result.IsSuccess? Results.Ok(result.Value): Results.NotFound(result.Error);
        });

        app.Run();
    }
}