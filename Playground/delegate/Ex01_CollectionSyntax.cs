namespace Play.linq;

public static class Ex01_CollectionSyntax
{
    public static void Run()
    {
        // Todo - 1
        // array literal
        int[] arr1 = {2, 4, 6, 8, 10};
        Console.WriteLine($"{string.Join(",", arr1)}");

        // a list<int> with a collection initializer
        List<int> list1 = new() { 2, 4, 6, 8, 10}; 
        Console.WriteLine($"{string.Join(",", list1)}");

        // a List<int> with [..]
        List<int> list2 = [2, 4, 6, 8, 10];
        Console.WriteLine($"{string.Join(",", list2)}");

        // Todo-2
        Dictionary<string, int> fruitPriceMap = new() {["apple"] = 3, ["banana"] = 1, ["cherry"] = 5};
        foreach(var (fruit, price) in fruitPriceMap)
        {
            Console.WriteLine($"Fruit: {fruit}, Price: {price}");
        }

        // Todo-3
        // build a HashSet
        HashSet<int> uniqueSet = new() {1, 2, 2, 3, 3, 3};
        Console.WriteLine($"{uniqueSet.Count}");

        // Todo-4
        // use Enumerable
        IEnumerable<int> numbers = Enumerable.Range(1, 5);
        List<int> generated = numbers.ToList();
        Console.WriteLine($"{string.Join(",", generated)}");
    }
}