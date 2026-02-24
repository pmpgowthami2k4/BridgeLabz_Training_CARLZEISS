//Given a list of Employee objects ( Id , Name, Department ), group employees by 
//Department and display each department with employee names
    
using System;
using System.Collections.Generic;
using System.Text;


public class Employee4
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}

public class groupingquestion1
{

    static void Main()
    {
        List<Employee4> employees = new List<Employee4>
    {
        new Employee4 { Id = 1, Name = "Alice", Department = "HR" },
        new Employee4{ Id = 2, Name = "Bob", Department = "IT" },
        new Employee4 { Id = 3, Name = "Charlie", Department = "HR" },
        new Employee4 { Id = 4, Name = "David", Department = "Finance" },
        new Employee4 { Id = 5, Name = "Eve", Department = "IT" }
    };

        var result = employees.GroupBy(emp => emp.Department);

        foreach (var group in result)
        {
            Console.WriteLine($"Department: {group.Key} ");
            foreach (var emp in group)
            {
                Console.WriteLine($" - {emp.Name}");
            }
            Console.WriteLine();
        }



    }
    
    
}
