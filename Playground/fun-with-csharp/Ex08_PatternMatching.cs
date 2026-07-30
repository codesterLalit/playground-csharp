using System.Security.Cryptography.X509Certificates;

namespace Play.fun;


public abstract record Shape3;
public sealed record Circle3(double Radius): Shape3;
public sealed record Rectangle3(double Width, double Height): Shape3;

public static class Ex08_PatternMatching
{
    public static double Area(Shape3 s)
    {
        double result = s switch
        {
          Circle3 circ => Math.PI * circ.Radius * circ.Radius,
          Rectangle3 rect => rect.Width * rect.Height,
          null => throw new ArgumentNullException(nameof(s))
        };
        return result;
    }
    public static void Run()
    {
        Circle3 circle3 = new Circle3(2);
        Rectangle3 rectangle3 = new Rectangle3(2, 3);
        double area = Area(circle3);
        double rectArea = Area(rectangle3);
        Console.WriteLine($"{area:f2}");
        Console.WriteLine($"{rectArea:f3}");

    }
}