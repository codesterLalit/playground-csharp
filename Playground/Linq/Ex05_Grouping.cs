namespace Play.linq;

public static class Ex05_Grouping
{
    public static void Run()
    {
        List<Sale> sales = new()
        {
            new Sale("Widget", 9.99m, 5),
            new Sale("Gadget", 19.99m, 2),
            new Sale("Gizmo", 14.99m, 8),
            new Sale("Widget", 9.99m, 3),
            new Sale("Gizmo", 14.99m, 1),
        };

        // TODO 1: GroupBy Product. For each group print:
        //         "{Key}: {count} sales, {totalQuantity} units, {totalRevenue} revenue"
        //         count = group.Count(), totalQuantity = group.Sum(Quantity),
        //         totalRevenue = group.Sum(Price * Quantity)
        var productGroups = sales.GroupBy(s=> s.Product);
        foreach(var productGroup in productGroups)
        {
            Console.WriteLine($"{productGroup.Key}: {productGroup.Count()} sales, {productGroup.Sum(p=>p.Quantity)}, {productGroup.Sum(p=> p.Price)} revenue.");
        }


        // TODO 2: same grouping, but project each group with Select into something
        //         holding just { Product, TotalRevenue } (anonymous type or a small
        //         record), then OrderByDescending(TotalRevenue) and print the ranked
        //         list — "which product made the most money," GroupBy + OrderBy chained.

    }
}
