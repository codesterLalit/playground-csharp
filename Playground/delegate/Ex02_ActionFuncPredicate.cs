namespace Play.delegates;

public static class Ex02_ActionFuncPredicate
{
    // TODO 1: return only the items where predicate(item) is true.
    //         (This is what LINQ's Where does under the hood.)
    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        var result = new List<T>();
        foreach(var item in items)
        {
            if(predicate(item))
            {
                 result.Add(item);
            }
        }
        return result;
    }

    // TODO 2: transform each item of type T into a TResult using selector.
    //         (This is what LINQ's Select does under the hood.)
    public static IEnumerable<TResult> Transform<T, TResult>(IEnumerable<T> items, Func<T, TResult> selector)
    {
        var result = new List<TResult>();

        foreach(var item in items)
        {
            result.Add(selector(item));
        }
        return result;
    }

    // TODO 3: run action against every item — no return value.
    //         (This is what List<T>.ForEach does under the hood.)
    public static void ForEach<T>(IEnumerable<T> items, Action<T> action)
    {
        foreach(var item in items)
        {
            action(item);
        }
    }

    public static void Run()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // TODO 4: use Filter with a Predicate<int> to keep only even numbers.
        Console.WriteLine("Even numbers:");
        var evenNumbers = Filter(numbers, n=> n % 2 ==0);
        Console.WriteLine(string.Join(", ", evenNumbers));

        // TODO 5: use Transform with a Func<int,int> to square each even number.
        var squaredNumbers = Transform(evenNumbers, n => n * n);
        Console.WriteLine("Squared even numbers:");
        Console.WriteLine(string.Join(", ", squaredNumbers));

        // TODO 6: use ForEach with an Action<int> to print each squared value.
        Console.WriteLine("Squared even numbers:");
        ForEach(squaredNumbers, n=> Console.WriteLine(n));
    }
}
