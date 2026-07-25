using System.Formats.Asn1;

namespace Play.fun;

public interface IShape
{
    double Area();
    double Perimeter();
}

public class Circle: IShape
{
    public double Radius {get; set;}
    public double Area() => Math.PI * Radius * Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
}

public interface INamed { string Name {get;}}

public class Rectangle: IShape
{
    public double Width {get; init;}
    public double Height {get; init;}
    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
}

public static class FunWithInterface
{
    public static void Run()
    {
        List<IShape> shapes = new() {new Circle{Radius = 2}, new Rectangle{Width = 22, Height= 11}};

        foreach (var s in shapes)
        {
            Console.WriteLine($"Area={s.Area()}, Perimeter={s.Perimeter()}");
        } 
    }
}