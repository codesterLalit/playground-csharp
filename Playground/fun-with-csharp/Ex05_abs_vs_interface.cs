namespace Play.fun;

public abstract class ShapeBase
{
    public abstract double Area();

    // a concerte method, shared by every subclasses -no interfaces can do this directly
    public string Describe() => $"{GetType().Name} has area of {Area():F2}";
}

public class Square: ShapeBase
{
    public double Side {get; init;}
    public override double Area() => Side * Side;
}

public static class EX05
{
    public static void Run() {
        Square square = new Square{Side = 2};
        Console.WriteLine(square.Describe());
    }
}