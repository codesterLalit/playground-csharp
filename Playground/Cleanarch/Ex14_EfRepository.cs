using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

// Lesson: this is the payoff promised back in Exercise 6 — IBookRepository is an abstraction that Application
// code can depend on, and EfBookRepository is a real, swappable implementation. Nothing about the interface
// changed to accommodate EF Core; if you wanted an InMemoryBookRepository instead (like Exercise 6's
// InMemoryProductRepository), you could add one without touching anything that depends on IBookRepository.

public static class Ex14_EfRepository
{
    public static void Run()
    {
        var services = new ServiceCollection();

        // TODO: register AppDbContext (plain 'new AppDbContext()' works for now — Exercise 15 covers
        //       registering it properly through the container)
        // TODO: register IBookRepository -> EfBookRepository

        using var provider = services.BuildServiceProvider();

        // TODO: resolve IBookRepository, Add a Book through it, then GetById it back and print the title
    }
}
