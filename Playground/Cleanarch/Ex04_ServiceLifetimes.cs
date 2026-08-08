using Microsoft.Extensions.DependencyInjection;

namespace Play.cleanarch;

public class SingletonTracker {public Guid InstanceId {get;} = Guid.NewGuid();}
public class ScopedTracker {public Guid InstanceId{get; } = Guid.NewGuid();}
public class TransientTracker {public Guid InstanceId{get;} = Guid.NewGuid();}

public static class Ex04_ServiceLifetimes
{
    public static void Run()
    {
        var services = new ServiceCollection();

        services.AddSingleton<SingletonTracker>();
        services.AddScoped<ScopedTracker>();
        services.AddTransient<TransientTracker>();

        using var provider = services.BuildServiceProvider();

        using (var scope1  = provider.CreateScope())
        {
            var singleton1 = scope1.ServiceProvider.GetRequiredService<SingletonTracker>();
            var singleton2 = scope1.ServiceProvider.GetRequiredService<SingletonTracker>();

            Console.WriteLine($"Singleton: {singleton1.InstanceId} vs {singleton2.InstanceId}");

            var scoped1 = scope1.ServiceProvider.GetRequiredService<ScopedTracker>();
            var scoped2 = scope1.ServiceProvider.GetRequiredService<ScopedTracker>();
            Console.WriteLine($"Scoped: {scoped1.InstanceId} vs {scoped2.InstanceId}");

            var transient1 = scope1.ServiceProvider.GetRequiredService<TransientTracker>();
            var transient2 = scope1.ServiceProvider.GetRequiredService<TransientTracker>();
            Console.WriteLine($"Transient: {transient1.InstanceId} vs {transient2.InstanceId}");
        }

        using (var scope2 = provider.CreateScope())
        {
            var singleton2 = scope2.ServiceProvider.GetRequiredService<SingletonTracker>();
            var scopedTracker2 = scope2.ServiceProvider.GetRequiredService<ScopedTracker>();

            Console.WriteLine("\n");
            Console.WriteLine($"Id of scope 2, singleton: {singleton2.InstanceId}");
            Console.WriteLine($"Id of scope 2, scopedTracker: {scopedTracker2.InstanceId}");
        }
    }
}