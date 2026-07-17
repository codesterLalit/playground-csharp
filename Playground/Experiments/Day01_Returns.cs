namespace Playground.Experiments;

public static class Day01_Returns
{
    public static void Run()
    {
        double yesterday = 100;
        double today = 103;

        double simpleReturn = (today- yesterday) / yesterday;
        double logReturn = Math.Log(today / yesterday);

        Console.WriteLine($"Simple return: {simpleReturn}");
        Console.WriteLine($"Log return: {logReturn}");
    }
}