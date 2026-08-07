namespace Play.cleanarch;

public interface ILogger
{
   public void log(string message); 
}

public class ConsoleLogger: ILogger
{
    public void log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

public class InMemoryLogger: ILogger
{
    public List<string> messages {get;} = [];
    public void log(string message)
    {
        messages.Add(message);
    }
}

public class OrderProcessor
{
    private ILogger _logger;
    public OrderProcessor(ILogger logger)
    {
        _logger = logger;
    }

    public void Process(string orderId)
    {
        _logger.log($"Processing order {orderId} via the injected logger");
    }
}

public static class Ex01_DependencyInversion
{
    public static void Run()
    {
        ConsoleLogger consoleLogger = new ConsoleLogger();
        InMemoryLogger inMemoryLogger = new InMemoryLogger();

        OrderProcessor orderProcessorByConsole = new OrderProcessor(consoleLogger);
        OrderProcessor orderProcessorByInMemory = new OrderProcessor(inMemoryLogger);

        orderProcessorByConsole.Process("320");
        orderProcessorByInMemory.Process("322");
        orderProcessorByInMemory.Process("324");
        Console.WriteLine(string.Join(",",inMemoryLogger.messages));
    }
}