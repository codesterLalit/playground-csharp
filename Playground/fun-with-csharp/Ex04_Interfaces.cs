using System.Formats.Asn1;

namespace Play.fun;

public interface IShape: INamed
{
    double Area();
    double Perimeter();
}
public interface INamed { string Name {get;}}

public class Circle: IShape
{
    public double Radius {get; set;}
    public double Area() => Math.PI * Radius * Radius;
    // public double Perimeter() => 2 * Math.PI * Radius;
    public string Name {get;} = "Circle";
    double IShape.Perimeter() => 2 * Math.PI * Radius;
}

public class Rectangle: IShape
{
    public double Width {get; init;}
    public double Height {get; init;}
    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
    public string Name {get;} = "Rectangle";
}

public static class FunWithInterface
{
    public static void Run()
    {
        List<IShape> shapes = new() {new Circle{Radius = 2}, new Rectangle{Width = 22, Height= 11}};

        foreach (var s in shapes)
        {
                Console.WriteLine($"{s.Name} has an Area={s.Area()}, Perimeter={s.Perimeter()}");   
        } 


        Console.WriteLine("*********- 6 - ***************");
        var c = new Circle{Radius = 2};
        // c.Perimeter(); // it doesn't work because 'Circle' does not contain a definition for 'Perimeter'
        IShape p = c;
        Console.WriteLine(p.Perimeter());

        // i think practical difference is that with explict implementation we don't really implement on child or inherited interface it stay on parent class.

    }
}