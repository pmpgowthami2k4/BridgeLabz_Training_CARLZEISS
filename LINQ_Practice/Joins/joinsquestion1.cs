//Perform an inner join between Employees and Departments to display employee name and
//department name.
    

using System;
using System.Collections.Generic;
using System.Text;

class Employee5
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }

    public Employee5(int id, string name, int departmentId)
    {
        Id = id;
        Name = name;
        DepartmentId = departmentId;
    }
}

class Department5
{
       public int Id { get; set; }
    public string DepartmentName { get; set; }

    public Department5(int id, string departmentName)
    {
        Id = id;
        DepartmentName = departmentName;
    }
}

public class joinsquestion1
{
    static void Main()
    {
        List<Employee5> employees = new List<Employee5>
        {
            new Employee5(1, "Alice", 1),
            new Employee5(2, "Bob", 2),
            new Employee5(3, "Charlie", 1),
            new Employee5(4, "David", 3),
            new Employee5(5, "Eve", 2)
        };

        List<Department5> depts = new List<Department5>
        {
            new Department5(1, "HR"),
            new Department5(2, "IT"),
            new Department5(3, "Finance")
        };


        var results = employees.Join(depts, 
            
            emp => emp.DepartmentId, 
            dept => dept.Id,
            (emp, dept) => new { EmployeeNaame = emp.Name, DeptName = dept.DepartmentName });



    }
}