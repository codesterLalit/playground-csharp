using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

// Lesson: AddDbContext<T>() registers your DbContext as Scoped by default — not an arbitrary choice.
// DbContext isn't thread-safe, and it tracks changes for a single unit of work; sharing one instance across
// unrelated operations (Singleton) risks stale/conflicting tracked state, while a new one per tiny operation
// (Transient) throws away the unit-of-work grouping that makes SaveChanges() meaningful. Scoped — one
// instance per logical operation/request — is the right middle ground. Same proof technique as Exercise 4:
// compare instance identity across resolutions.

public static class Ex15_DbContextLifetime
{
    public static void Run()
    {
        var services = new ServiceCollection();

        // TODO: services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=cleanarch.db"));
        // TODO: register IBookRepository -> EfBookRepository

        using var provider = services.BuildServiceProvider();

        using (var scope1 = provider.CreateScope())
        {
            // TODO: resolve AppDbContext TWICE from scope1.ServiceProvider
            // TODO: compare their identity (e.g. ReferenceEquals or GetHashCode()) and print the result
            //       — expect: same instance, same as Exercise 4's Scoped result
        }

        using (var scope2 = provider.CreateScope())
        {
            // TODO: resolve AppDbContext once from scope2, compare it against scope1's instance
            //       — expect: different instance

            // TODO: resolve IBookRepository, add a Book through it — proving the whole chain
            //       (Scoped DbContext -> EfBookRepository -> use) works end to end
        }
    }
}
