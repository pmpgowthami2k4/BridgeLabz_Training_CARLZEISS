//Projection using Select
//Given a list of Student objects (Id, Name, Marks), use LINQ to project only Name and Grade
//(Grade = Pass if Marks ≥ 40 else Fail).
    
using System;
using System.Collections.Generic;
using System.Text;

public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }


    public Student(int id, string name,int marks)
    {
        ID = id;
        Name = name;
        Marks = marks;
    }
}

class projection1
{
    static void Main()
    {
        List<Student> students = new List<Student>
    {
        new Student(1, "Ravi", 85),
        new Student(2, "Priya", 35),
        new Student(3, "Arun", 60),
        new Student(4, "Meena", 25)
    };

        var results = students.Select(s => new
        {
            s.Name,
            Grade = s.Marks > 40 ? "Pass" : "Fail"
        });

        Console.WriteLine("RESULTS");
        foreach(var result in results)
        {
            Console.WriteLine($"{result.Name} - {result.Grade}");
        }
}

}