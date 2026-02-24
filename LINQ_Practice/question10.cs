//. Joining Collections
//Given two collections:
//Employee(Id, Name, DepartmentId)
//Department(DepartmentId, DepartmentName)
//Use LINQ with lambda expressions to join both collections and display Employee Name
//along with Department Name .
    
using System;
using System.Collections.Generic;
using System.Text;

public class Employee3
{
    public int id { get;set; }
    public string name { get;set; }
    public string department { get;set; }
}

public class Department
{
    public int departmentId { get;set; }
    public string departmentName { get;set; }
}

class question10
{
    static void Main()
    {
        List<Employee3> employees = new List<Employee3>
        {
            new Employee3 {id = 1, name = "Alice", department = "HR" },
            new Employee3 {id = 2, name = "Bob", department = "IT"},
            new Employee3 {id = 3, name = "Charlie", department = "Finance"}
        };

        List<Department> departments = new List<Department>
        {
            new Department { departmentId = 1, departmentName = "HR" },
            new Department { departmentId = 2, departmentName = "IT" },
            new Department { departmentId = 3, departmentName = "Finance" }
        };

        var result = employees.Join(departments,
            emp=>emp.department,
            dept=>dept.departmentName,
            (emp, dept) => new { EmployeeName = emp.name, DepartmentName = dept.departmentName });

        Console.WriteLine("Employee with department: \n");

        foreach (var item in result)
        {
            Console.WriteLine($"Employee Name: {item.EmployeeName}, Department Name: {item.DepartmentName}");
        }
    }
}