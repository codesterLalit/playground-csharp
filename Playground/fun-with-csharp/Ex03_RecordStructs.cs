using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Play.fun;

public record class PointRef(int X, int Y);
public record struct PointVal(int X, int Y);

public static class Ex03_RecordStructs
{
    public static void Run()
    {
        var a = new PointRef(2, 3);
        var b = a;
        Console.WriteLine(ReferenceEquals(a, b)); // True
        b = b with {X = 5};

        Console.WriteLine(ReferenceEquals(a, b)); // false
        Console.WriteLine($"a- x = {a.X} and y = {a.Y}"); // a- x = 2 and y = 3
        Console.WriteLine($"b- x = {b.X} and y = {b.Y}"); // b- x = 5 and y = 3


        var x = new PointVal(5, 6);
        var y = x;
        y.X = 99;

        Console.WriteLine($"X- x = {x.X} and y = {x.Y}"); // X- x = 5 and y = 6
        Console.WriteLine($"Y- x = {y.X} and y = {y.Y}"); // X- x = 99 and y = 6

        // because it is value 
    }
}