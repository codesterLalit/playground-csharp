namespace Playground.Experiments;

public static class Day03_Sharpe
{
    public static double AnnualisedReturn(double[] returns)
    {
        return returns.Average() * 252;
    }

    public static double SharpeRatio(double[] returns, double riskFreeRate)
    {
        double annualReturn = AnnualisedReturn(returns);
        double annualVol = Day02_Volatility.AnnualisedVolatility(returns);
        return (annualReturn - riskFreeRate) / annualVol;
    }

    public static void Run()
    {
        double[] returns = { 100, 102, 101, 105, 103 };
        double riskFreeRate = 0.02;

        double annualReturn = AnnualisedReturn(returns);
        double sharpe = SharpeRatio(returns, riskFreeRate);

        Console.WriteLine($"Annualised return: {annualReturn}");
        Console.WriteLine($"Sharpe Ration: {sharpe}"); 
    }
}