//. Given a list of employees ( Department , Salary ), group by department and calculate the
//minimum, maximum, and average salary

using System;
using System.Collections.Generic;
using System.Linq;

public class Employee8
{
  
    public string Name { get; set; }
    public string Department { get; set; }  
    public int Salary { get; set; }

    public Employee8(string name, string dept, int salary)
    {
        Name = name;
        Department = dept;
        Salary = salary;
    }

}

class groupingquestion8
{
    static void Main()
    {
        List<Employee8> employees = new List<Employee8>
        {
            new Employee8("Ram", "IT", 90000),
            new Employee8("tom","HR",8000),
            new Employee8("Raj","HR",7000),
            new Employee8("Khushi", "IT", 69000),
            new Employee8("Khush", "HR", 67000),
            new Employee8("Sam", "Bla", 64500),
            new Employee8("Samira", "Bla", 64700),
            new Employee8("Khushi", "IT", 69000),
            

        };

        var result = employees.GroupBy(e => e.Department).Select(emp => new
        {
            Department = emp.Key,
            MinSalary = emp.Min(e => e.Salary),
            MaxSalary = emp.Max(e => e.Salary),
            AvgSalary = emp.Average(e => e.Salary),

        });

        foreach(var emp in result)
        {
            Console.WriteLine($"DeptName: {emp.Department} : Minsal: {emp.MinSalary} : MaxSal= {emp.MaxSalary}  : AvgSal: {emp.AvgSalary}");
        }
    }
}