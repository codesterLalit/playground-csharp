namespace Play.fun;

public static class Ex07_Generics
{
    public static T Max<T>(T a, T b)  where T : IComparable<T>
    {
        if(a.CompareTo(b) >= 0)
        {
            return a;
        }else
        {
            return b;
        }
    }

    public static void Run()
    {
        string a = Max("test2", "test");
        Console.WriteLine($"max-> {a}");
    }
}