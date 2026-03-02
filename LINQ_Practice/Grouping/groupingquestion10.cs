//using System.Text.RegularExpressions;

//Group students by Pass/Fail status (Marks ≥ 40 → Pass) and count how many students fall into
//each group.


public class Student10
{
    public string Name { get; set; }
    public int Marks { get; set; }

    public Student10(string name, int marks)
    {
        Name = name;
        Marks = marks;
    }

}

class groupingquestion10
{
    static void Main()
    {
        List<Student10> students = new List<Student10>
    {
        new Student10("Alice", 85),
        new Student10("Bob", 35),
        new Student10("Charlie", 45),
        new Student10("David", 30),
        new Student10("Eve", 90)
    };

        var result = students.GroupBy(s => s.Marks >= 40 ? "Pass" : "Fail").Select(s => new { Status = s.Key, Count = s.Count() });
        
        foreach (var group in result)
        {
            Console.WriteLine($"{group.Status}: {group.Count}");
        }
    }

    
}