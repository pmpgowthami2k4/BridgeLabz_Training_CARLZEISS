//Grouping with Count
//Given a list of Employee objects (Id, Name, Department), use LINQ to group employees by
//department and display the number of employees in each department.

using System;
using System.Collections.Generic;
using System.Text;

public class Employee2
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public Employee2(int id, string name, string department)
    {
        ID = id;
        Name = name;
        Department = department;
    }
}

class grouping2
{
    static void Main()
    {
        List<Employee2> employees = new List<Employee2>
        {
            new Employee2(1, "Alice", "HR"),
            new Employee2(2, "Bob", "IT"),
            new Employee2(3, "Charlie", "HR"),
            new Employee2(4, "David", "IT"),
            new Employee2(5, "Eve", "Finance")

        };

        var departmentGroups = employees.GroupBy(e => e.Department).Select(e => new { Department = e.Key, Count = e.Count() });

        Console.WriteLine("Details");
        foreach (var group in departmentGroups)
        {
            Console.WriteLine($"Department: {group.Department}, Count: {group.Count}");
        }   
    }

}