//Group employees by department and count how many employees joined in each department.

using System;
using System.Collections.Generic;  
using System.Linq;

public class Employee7
{
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string  DeptName { get; set; }
    public Employee7(int employeeID, string employeeName, string deptName)
    {
        EmployeeID = employeeID;
        EmployeeName = employeeName;
        DeptName = deptName;
    }
}

class groupingquestions5
{

    static void Main()
    {


        List<Employee7> employees = new List<Employee7>

    {
       new Employee7(1, "Alice", "HR"),
       new Employee7(2, "Bob", "IT"),
       new Employee7(3, "Charlie", "HR"),
       new Employee7(4, "David", "Finance"),
       new Employee7(5, "Eve", "IT"),
       new Employee7(6, "Frank", "HR"),
    };



        var result = employees.GroupBy(e => e.DeptName).Select(g => new
        {
            Dept = g.Key,
            EmployeeCount = g.Count()
        });


        foreach (var item in result)
        {
            Console.WriteLine($"Department: {item.Dept}, Employee Count: {item.EmployeeCount}");
        }
    }
}