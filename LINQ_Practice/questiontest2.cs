using System;
using System.Collections.Generic;
using System.Text;

public class Employee6
{
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public int DeptId { get; set; }

    public Employee6(int employeeID, string employeeName, int deptId)
    {
        EmployeeID = employeeID;
        EmployeeName = employeeName;
        DeptId = deptId;
    }
}

public class Department2
{
    public string DeptName { get; set; }
    public int Id { get; set; }
    public string Location { get; set; }

    public Department2(string deptName, int id, string location)
    {
        DeptName = deptName;
        Id = id;
        Location = location;
    }

}

class question2
{

    static void Main()
    {

        List<Employee6> employees = new List<Employee6>
        {
            new Employee6(1, "Alice", 1),
            new Employee6(2, "Bob", 2),
            new Employee6(3, "Charlie", 1),
            new Employee6(4, "David", 3),
            new Employee6(5, "Eve", 2)
        };

        List<Department2> depts = new List<Department2>
        {
            new Department2("HR", 1, "KNCHPRM"),
            new Department2("IT", 2 , "DELHI"),
            new Department2("Finance", 3, "HYD")
        };



        var result = employees.Join(depts,
            emp => emp.DeptId,
            dep => dep.Id,
            (emp, dep) => new
            {
                Name = emp.EmployeeName,
                DepartmentName = dep.DeptName,
                Location = dep.Location

            }

            ).ToList();
        result.ForEach(emp=> Console.WriteLine(emp));

        foreach (var emp in result) {
            Console.WriteLine($"Emp Name : {emp.Name}  DeptName; {emp.DepartmentName}, Location: {emp.Location}");
        
        }
    }
}

