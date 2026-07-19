namespace Playground.Experiments;

public static class Day04_MaxDrawdown
{
    public static double MaxDrawndown(double[] values)
    {
        double runningMax = values[0];
        double worstDrawdown = 0;

        foreach(var value in values)
        {
            runningMax = Math.Max(runningMax, value);
            double drawdown = (value - runningMax) / runningMax;
            worstDrawdown = Math.Min(worstDrawdown, drawdown);
        }
        return worstDrawdown;
    }

    public static void Run()
    {
        double[] portfolioValues = {100, 110, 105, 90, 95, 120};
        double maxDd = MaxDrawndown(portfolioValues);
        Console.WriteLine($"Max drawdown: {maxDd}");
    }
}