namespace Play.delegates;

public static class Ex03_MulticastDelegates
{
    public static void Run()
    {
        Action<string>? notify = null;

        Action<string> consoleHandler = msg => Console.WriteLine($"Console {msg}");
        notify += consoleHandler;
        notify += msg => Console.WriteLine($"Log: {msg}");

        notify("hello");
        Console.WriteLine("Changed \n");

        notify -= consoleHandler;
        notify("hello 2");
    }
}