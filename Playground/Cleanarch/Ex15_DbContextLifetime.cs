using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Play.cleanarch.Application;
using Play.cleanarch.Domain;
using Play.cleanarch.Infrastructure;

namespace Play.cleanarch;

public static class Ex15_DbContextLifetime
{
    public static void Run()
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>();
        services.AddScoped<IBookRepository, EfBookRepository>();

        using var provider = services.BuildServiceProvider();
        AppDbContext? db1 = null;

        using (var scope1 = provider.CreateScope())
        {
            db1 = scope1.ServiceProvider.GetRequiredService<AppDbContext>();
            var db2 = scope1.ServiceProvider.GetRequiredService<AppDbContext>();

            Console.WriteLine($"Are db1 and db2 equal: {ReferenceEquals(db1, db2)}");
        }

        using (var scope2 = provider.CreateScope())
        {
            var db3 = scope2.ServiceProvider.GetRequiredService<AppDbContext>();
            Console.WriteLine($"Same Across scopes: {ReferenceEquals(db1, db3)}");

            var ibookRep = scope2.ServiceProvider.GetRequiredService<IBookRepository>();
            var HarryPotter2 = new Book(10, "Harry potter 2", 2, 2004);
            ibookRep.Add(HarryPotter2);
            
            var fetchedbook = ibookRep.GetById(10);
            Console.WriteLine(fetchedbook?.Title);
        }
    }
}