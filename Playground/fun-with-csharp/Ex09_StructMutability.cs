namespace Play.fun;

public struct MutablePoint
{
    public int X {get; set;}
    public int Y {get; set;}
}

public static class Ex09_StructMutability
{
    public static void TryModify(MutablePoint p)
    {
        p.X  = 99;        
    }
    public static void Run()
    {
        List<MutablePoint> mutablePoint = new() { new MutablePoint{X = 1, Y = 2}, new MutablePoint{X = 4, Y = 3}};
        
        foreach (var p in mutablePoint)
        {
            // p.X = 9; // doesn't change
            TryModify(p);
            Console.WriteLine($"p: {p.X}");
        }
    }
}