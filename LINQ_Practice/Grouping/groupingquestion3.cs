//. Group a list of students ( Name , Class, Marks ) by Class and nd the highest marks in each
//class.

using System;
using System.Collections.Generic;
using System.Text;

public class Student1
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Marks { get; set; }
    public Student1(string name, string className, int marks)
    {
        Name = name;
        Class = className;
        Marks = marks;
    }
}

public class groupingquestion3
{

    static void Main()
    {
        List<Student1> students = new List<Student1>
    {
        new Student1("Alice", "10th Grade", 85),
        new Student1("Bob", "10th Grade", 90),
        new Student1("Charlie", "11th Grade", 80),
        new Student1("David", "11th Grade", 95),
        new Student1("Eve", "10th Grade", 88)
    };
        var result = students.GroupBy(s => s.Class).Select(g => new
        {
            Class = g.Key,
            Marks = g.Max(students => students.Marks)
        });

        foreach (var item in result)
        {
            Console.WriteLine($"Class: {item.Class}, Highest Marks: {item.Marks}");
        }



    }


}