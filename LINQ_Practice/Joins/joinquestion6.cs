//Perform a join between employees and projects to display employees who are not assigned to any
//project.
// join, define columns, condition where x.projects.any() is false, select employee name
public class Employee9
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Employee9(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Project6
{
    public int EmployeeId { get; set; }
    public string ProjectName { get; set; }
    public Project6(int employeeId, string projectName)
    {
        EmployeeId = employeeId;
        ProjectName = projectName;
    }
}

class joinquestion6
{
    static void Main()
    {
        List<Employee9> employees = new List<Employee9>
        {
            new Employee9(1, "Alice"),
            new Employee9(2, "Bob"),
            new Employee9(3, "Charlie")
        };
        List<Project6> projects = new List<Project6>
        {
            new Project6(1, "Project A"),
            new Project6(2, "Project B")
        };
        var result = employees.GroupJoin(projects,
            e => e.Id,
            p => p.EmployeeId,
            (e, p) => new { EmployeeName = e.Name, Projects = p })
            .Where(x => !x.Projects.Any())
            .Select(x => x.EmployeeName);
        Console.WriteLine("Employees not assigned to any project:");
        foreach (var employee in result)
        {
            Console.WriteLine(employee);
        }
    }
}