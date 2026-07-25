namespace Play.fun;

public interface IShape
{
    double Area();
    double Perimeter();
}

public class Circle : IShape
{
    public double Radius { get; init; }
    // TODO: implement Area() and Perimeter()
}

public class Rectangle : IShape
{
    public double Width { get; init; }
    public double Height { get; init; }
    // TODO: implement Area() and Perimeter()
}

public static class Ex04_Interfaces
{
    public static void Run()
    {
        // TODO:
        // 1. Create a Circle and a Rectangle.
        // 2. Put both into a single List<IShape>.
        // 3. Loop over the list and print each shape's Area() and Perimeter() —
        //    notice you never had to check "is this a Circle or a Rectangle" to call them.
        // 4. Try assigning `IShape s = new Circle { Radius = 2 };` directly.
        //    Can you call s.Radius from that variable? Why or why not?
        // 5. Bonus: add a second interface `INamed { string Name { get; } }`,
        //    implement it on both Circle and Rectangle too (a class can implement
        //    multiple interfaces), and print each shape's Name alongside its Area.
        //    List<IShape> can now know Names? What has to change to make that work?
        //    (Hint: think about what List<IShape> knows vs. what List<Circle> knows.)
        //    -- Hmm, actually think about it: does IShape need to also require INamed,
        //    or should shapes implement both separately and you cast/check when needed?
        //    Try it both ways if you're not sure.
        // 6. Bonus: try declaring `public double Area() => Math.PI * Radius * Radius;`
        //    as an EXPRESSION-BODIED member (no braces/return) instead of a full method body.
        //    Does it compile the same?
        // 7. Bonus: try explicit interface implementation for one method
        //    (`double IShape.Perimeter() => ...`), then try calling shapeInstance.Perimeter()
        //    directly on a Circle variable vs. through an IShape variable. What differs?
        //    (This one previews something useful, don't worry if it's confusing at first.)
        // 8. NEW built-in interface preview (since you asked about IList):
        //    Make Ex04_Interfaces also build a List<Circle> circles = new();
        //    add a few circles, and print circles.Count and loop with foreach.
        //    Then check: is List<T> itself something you could substitute an IList<T>,
        //    ICollection<T>, or IEnumerable<T> for? We'll dig into *why* those exist
        //    and what each one guarantees next challenge — for now just notice that
        //    List<T> implements all three.
    }
}
