namespace Play.cleanarch;

// Lesson: everything so far has run as a one-shot console call. A real Clean Architecture app usually sits
// behind a web API — the "Presentation" layer. It depends on Application (use cases) and nothing else; its
// only job is translate an HTTP request into a use-case request, call Execute(), translate the response
// back to HTTP. No business logic belongs here — if you find yourself writing domain rules inside a minimal
// API handler, that logic belongs in a use case instead.
//
// SETUP required before this compiles (not yet applied to Playground.csproj):
//   Add this line inside the existing <ItemGroup> (or a new one) in Playground.csproj:
//     <FrameworkReference Include="Microsoft.AspNetCore.App" />
//   This lets a plain console-SDK project use ASP.NET Core's WebApplication/minimal API types without
//   switching the whole project to Sdk="Microsoft.NET.Sdk.Web".
//
// NOTE: unlike every other exercise, calling this Run() will BLOCK — app.Run() starts a web server and
// listens for requests until you Ctrl+C. Don't leave this wired as the active line in Program.cs when you
// want a normal one-shot `dotnet run` for other exercises.

public static class Ex10_Capstone
{
    public static void Run()
    {
        // TODO: var builder = WebApplication.CreateBuilder();
        // TODO: register IProductRepository -> InMemoryProductRepository, AddProductUseCase, GetProductUseCase
        //       on builder.Services — same registrations as Exercise 7, just on the host's DI container
        //       instead of a standalone ServiceCollection
        // TODO: var app = builder.Build();

        // TODO: app.MapPost("/products", (AddProductRequest request, AddProductUseCase useCase) => useCase.Execute(request));
        // TODO: app.MapGet("/products/{id}", (int id, GetProductUseCase useCase) => useCase.Execute(new GetProductRequest(id)));
        //       minimal API resolves AddProductUseCase/GetProductUseCase from the container automatically,
        //       per request — DI doing its job all the way out to the HTTP layer, no manual GetRequiredService calls

        // TODO: app.Run();

        // Test with:
        //   curl -X POST http://localhost:5000/products -H "Content-Type: application/json" -d "{\"id\":1,\"name\":\"Iphone 17\",\"price\":999}"
        //   curl http://localhost:5000/products/1
    }
}
