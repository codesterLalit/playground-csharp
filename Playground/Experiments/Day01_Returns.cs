namespace Playground.Experiments;

public static class Day01_Returns
{
    public static void Run()
    {
        double[] price = {100, 103, 101, 105};
        double[] returns = SimpleReturn(price);

        Console.WriteLine("Daily simple returns:");
        foreach (var r in returns)
        {
            Console.WriteLine(r);
        }
    }

    public static double[] SimpleReturn(double[] prices)
    {
        var returns = new double[prices.Length - 1];

        for(int i = 1; i < prices.Length; i++)
        {
            returns[i-1] = (prices[i] - prices[i - 1]) / prices[i - 1];
        }
        return returns;
    }
}