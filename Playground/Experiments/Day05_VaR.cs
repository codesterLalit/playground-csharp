namespace Playground.Experiments
{
    public static class Day05_VaR
    {
        public static double HistoricalVaR95(double[] returns)
        {
            double[] sorted = (double[])returns.Clone();
            Array.Sort(sorted);

            double position = 0.05 * (sorted.Length - 1);

            int lowerIndex = (int) Math.Floor(position);
            int upperIndex = (int) Math.Ceiling(position);

            double fraction = position - lowerIndex;

            double lowerValue = sorted[lowerIndex];
            double upperValue = sorted[upperIndex];

            return lowerValue + fraction * (upperValue - lowerValue);
        }

        public static void Run()
        {
            double[] returns = {0.01, -0.02, 0.03, -0.05, 0.02, -0.01, 0.015, -0.03, 0.005, -0.008};

            double var95 = HistoricalVaR95(returns);
            Console.WriteLine($"Historical VaR (95%): {var95}");
        }
    }
}