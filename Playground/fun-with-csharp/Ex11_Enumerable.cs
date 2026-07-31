namespace Play.fun;

public class NumberRange: IEnumerable<int>
{
    private int _start;
    private int _end;
    public NumberRange(int start, int end)
    {
        _start = start;
        _end = end;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = _start; i <= _end; i++)
        {
            yield return i;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class Ex11_Enumerable
{
    public static void Run()
    {
        NumberRange range = new NumberRange(1, 5);
        foreach (var item in range)
        {
            Console.WriteLine($"value= {item}");
        }

        int sum = range.Sum();
        Console.WriteLine($"Sum = {sum}");
    }
}