using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;


public class Employee
{
    public int Salary { get; set; }
    public string Name
    { get; set; }
    public  string Department { get; set; }
}

class filtering1
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Ravi", Department = "IT", Salary = 60000 },
            new Employee { Name = "Priya", Department = "HR", Salary = 55000 },
            new Employee { Name = "Arun", Department = "IT", Salary = 45000 },
            new Employee { Name = "Meena", Department = "IT", Salary = 75000 }
        };

        var result = employees.Where(s => s.Salary > 50000 && s.Department == "IT");

        foreach (var employeee in result)
        {
            Console.WriteLine($"Name: {employeee.Name}, Department: {employeee.Department}, Salary: {employeee.Salary}");
        }
    }
}