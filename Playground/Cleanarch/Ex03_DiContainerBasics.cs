using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Play.cleanarch;

public static class Ex03_DiContainerBasics
{
    public static void Run()
    {
        var service  = new ServiceCollection();

        service.AddSingleton<ILogger, ConsoleLogger>();
        service.AddSingleton<INotifier, SmsNotifier>();
        service.AddTransient<ShippingService>();



        using var provider = service.BuildServiceProvider();
        var ShippingService = provider.GetRequiredService<ShippingService>();
        ShippingService.Ship("A2341233");

    }
}