//Join two collections using a composite key(e.g., EmployeeId + DepartmentId).

using System;
using System.Collections.Generic;
using System.Linq;

public class Employeej8
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public Employeej8(int id, string name, int departmentId)
    {
        Id = id;
        Name = name;
        DepartmentId = departmentId;
    }
}

public class Departmentj8
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Departmentj8(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class joinsquestion8
{
    static void Main()
    {
        List<Employeej8> employees = new List<Employeej8>
        {
            new Employeej8(1, "Alice", 101),
            new Employeej8(2, "Bob", 102),
            new Employeej8(3, "Charlie", 101)
        };
        List<Departmentj8> departments = new List<Departmentj8>
        {
            new Departmentj8(101, "HR"),
            new Departmentj8(102, "IT")
        };
        var employeeDepartments = departments.Join(employees,
            d => d.Id,
            e => e.DepartmentId,
            (d, e) => new { EmployeeName = e.Name, DepartmentName = d.Name });  
        foreach (var ed in employeeDepartments)
        {
            Console.WriteLine($"Employee: {ed.EmployeeName}, Department: {ed.DepartmentName}");
        }
    }
}