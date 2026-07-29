using System.Security.Cryptography.X509Certificates;

namespace Play.fun;

public interface IShape2
{
    double Area();
    string Label => "Shape"; // default property - no implementer is forced to define
}

public class Circle2: IShape2
{
    public double Radius {get; init;}
    public double Area() => Math.PI * Radius * Radius;
    // no label here
}

public class Square2: IShape2
{
    public double Side {get; init;}
    public double Area() => Side * Side;
    public string Label => "Square";
}


public static class Ex06Defaults
{
    public static void Run()
    {
        IShape2 circle = new Circle2{Radius = 5};
        IShape2 square = new Square2{Side = 3};

        Circle2 circle2 = new Circle2{Radius =2};
        Console.WriteLine(circle.Label);
        Console.WriteLine(square.Label);
        // Console.WriteLine(circle2.Label); // does't complies
    }
}