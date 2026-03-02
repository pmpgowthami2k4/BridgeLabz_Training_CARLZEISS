//Join Students and Courses collections to display student names and enrolled course names.

using System;
using System.Collections.Generic;
using System.Linq;

public class Student4
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Student4(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Course
{
    public int StudentId { get; set; }
    public string CourseName { get; set; }
    public Course(int studentId, string courseName)
    {
        StudentId = studentId;
        CourseName = courseName;
    }
}

class joinsquestion4
{
    static void Main()
    {
        List<Student4> students = new List<Student4>
        {
            new Student4(1, "Alice"),
            new Student4(2, "Bob"),
            new Student4(3, "Charlie")
        };
        List<Course> courses = new List<Course>
        {
            new Course(1, "Mathematics"),
            new Course(1, "Physics"),
            new Course(2, "Chemistry"),
            new Course(3, "Biology")
        };
        var result = students.Join(courses,
            s => s.Id,
            c => c.StudentId,
            (s,c) => new { studentname  = s.Name, coursename = c.CourseName }); 

        foreach (var item in result)
        {
            Console.WriteLine($"Student: {item.studentname}, Course: {item.coursename}");
        }
    }
}
