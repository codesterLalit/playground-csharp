namespace Play.linq;

public record Employee(string Name, string Department, decimal Salary);

public static class Ex03_Ordering
{
    public static void Run()
    {
        List<Employee> employees = new()
        {
            new Employee("Ana", "Engineering", 95000),
            new Employee("Bilal", "Sales", 65000),
            new Employee("Chen", "Engineering", 88000),
            new Employee("Deepa", "Sales", 72000),
            new Employee("Elin", "Engineering", 88000),
        };

        // TODO 1: Order employees by Salary descending (highest first)
        Console.WriteLine("=== Order by Salary Descending ===");

        employees
            .OrderByDescending(e => e.Salary)
            .ToList()
            .ForEach(e => Console.WriteLine($"{e.Name}: {e.Salary}"));

        Console.WriteLine();


        // TODO 2: Order by Department ascending, then Salary descending
        Console.WriteLine("=== Department, then Salary Descending ===");

        employees
            .OrderBy(e => e.Department)
            .ThenByDescending(e => e.Salary)
            .ToList()
            .ForEach(e =>
                Console.WriteLine($"{e.Department} | {e.Name}: {e.Salary}")
            );

        Console.WriteLine();


        // TODO 3: Two separate OrderBy calls
        Console.WriteLine("=== OrderBy().OrderBy() ===");

        employees
            .OrderBy(e => e.Department)
            .OrderBy(e => e.Salary)
            .ToList()
            .ForEach(e =>
                Console.WriteLine($"{e.Department} | {e.Name}: {e.Salary}")
            );
    }
}