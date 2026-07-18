namespace Playground.Experiments;

public static class Day02_Volatility
{
    public static double Variance(double[] returns)
    {
        double mean = returns.Average();

        double sumOfSquares = returns
                    .Select(r => Math.Pow(r - mean, 2))
                    .Sum();
        return sumOfSquares / (returns.Length - 1);
    }

    public static double StandardDeviation(double[] returns){
        return Math.Sqrt(Variance(returns));
    }

    public static double AnnualisedVolatility(double[] returns)
    {
        return StandardDeviation(returns) * Math.Sqrt(252);
    }

    public static void Run()
    {
        double[] returns = {0.02, -0.01, 0.03, -0.02};

        double variance = Variance(returns);
        double stdDev = StandardDeviation(returns);
        double annualVol = AnnualisedVolatility(returns);

        Console.WriteLine($"Variance: {variance}");
        Console.WriteLine($"Standard Deviation: {stdDev}");
        Console.WriteLine($"Annualised volatility: {annualVol}");
    }
}