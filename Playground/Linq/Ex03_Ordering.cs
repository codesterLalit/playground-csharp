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

        // TODO 1: order employees by Salary descending (highest first), print "Name: Salary".
        var salaryList = employees.OrderByDescending(p => p.Salary)
            .Select(p=> $"{p.Name}: {p.Salary}")
            .ToList();
        Console.WriteLine($"{string.Join(",", salaryList)}");
        
        Console.WriteLine("\n");
        // TODO 2: order employees by Department ascending, then by Salary descending
        //         within each department (use OrderBy + ThenByDescending), print
        //         "Department | Name: Salary" for each.
        var departmentSalaryDes = employees.OrderBy(p=> p.Department).ThenByDescending(p=>p.Salary)
                .Select(p=>$"{p.Department} | {p.Name}: {p.Salary}")
                .ToList();
                foreach(var employe in departmentSalaryDes)
                {
                    Console.WriteLine(employe);
                }


        // TODO 3: prove the OrderBy-vs-ThenBy distinction — chain
        //         employees.OrderBy(e => e.Department).OrderBy(e => e.Salary)
        //         (two separate OrderBy calls) and print it. Compare the order of
        //         Chen/Elin (same Salary, same Department) against what TODO 2 produced.
        //         Note in a comment what's different and why.
        
        var salaryDepartmentDes = employees.OrderBy(p=> p.Department).OrderBy(p=> p.Salary)
            .Select(p=>$"{p.Department} | {p.Name}: {p.Salary}")
            .ToList();

            Console.WriteLine("\n");
            foreach(var employe in salaryDepartmentDes)
            {
                Console.WriteLine(employe);
            }

            // both 2 and 3 yeild different result 

    }
}
