namespace Play.cleanarch;

public interface INotifier
{
    public void Notify(string recipient, string message);
}

public class SmsNotifier: INotifier
{
    private ILogger _logger;

    public SmsNotifier(ILogger logger)
    {
        _logger = logger;
    }

    public void Notify(string recipient, string message)
    {
        _logger.log($"Notifiy sent to {recipient}, with message: {message}");
    }
}

    public class ShippingService
    {
        private INotifier _notifier;
        private ILogger _logger;

        public ShippingService(INotifier notifier, ILogger logger)
        {
            _notifier = notifier;
            _logger = logger;
        }

        public void Ship(string orderId)
        {
            _logger.log($"Shipping order {orderId} via ILogger");
            _notifier.Notify("customer",$"Your order {orderId}");
        }
    }

public static class Ex02_ConstructorInjection
{
    public static void Run()
    {
        ConsoleLogger consoleLogger = new ConsoleLogger();
        SmsNotifier smsNotifier = new SmsNotifier(consoleLogger);
        ShippingService shippingService = new ShippingService(smsNotifier, consoleLogger);
        shippingService.Ship("A2341");
    }
}