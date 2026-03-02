//Perform a self join on the Employee collection to display employee–manager relationships

using System;
using System.Collections.Generic;
using System.Linq;

public class Employeej9
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ManagerId { get; set; }
    public Employeej9(int id, string name, int? managerId)
    {
        Id = id;
        Name = name;
        ManagerId = managerId;
    }
}

class joinsquestion9
{
    static void Main()
    {
        List<Employeej9> employees = new List<Employeej9>
        {
            new Employeej9(1, "Alice", null ),
            new Employeej9(2, "Bob", 1),
            new Employeej9(3, "Charlie", 1),
            new Employeej9(4, "David", 2)
        };
        var employeeManager = employees.Join(employees,
            e => e.ManagerId,
            m => m.Id,
            (e, m) => new { EmployeeName = e.Name, ManagerName = m.Name });
        foreach (var em in employeeManager)
        {
            Console.WriteLine($"Employee: {em.EmployeeName}, Manager: {em.ManagerName}");
        }
    }
}