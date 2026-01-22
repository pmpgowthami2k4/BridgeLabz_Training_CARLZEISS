//C: \Users\gowth\source\repos\OOPs_practice\OOPs_practice.csproj
//C: \Users\gowth\source\repos\OOPs_practice\OOPs_practice.csproj
using System;

abstract class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set {
            if (string.IsNullOrEmpty(value))
                name = "Unknown";
            else
                name = value;
        }

    }
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
                age = 0;
            else
                age = value;
        }

    }

    protected Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age {Age} ");
    }

    public abstract void GetRole();
    
}


interface IStudy
{
    void study();
}

interface ITeach
{
    void teach();
}

interface IWork
{
    void work();
}


class Student : Person, IStudy
{
    public int RollNumber;

    public Student(string name, int age, int rollNumber): base(name, age)
    {
        RollNumber = rollNumber;
    }

    public void DisplayStudentInfo()
    {
        DisplayInfo ();
        Console.WriteLine($"Roll Number: {RollNumber}");

    }

    public override void GetRole()
    {
        Console.WriteLine("I'm a STUDENT in the school");
    }

    public void study()
    {
        Console.WriteLine("STUDENT is studying.");
    }
}

class Teacher : Person, ITeach
{
    public string subject;

    public Teacher(string name, int age, string subject) : base(name, age)
    {
        this.subject = subject;
    }
    public void DisplayTeacherInfo()
    {
        DisplayInfo();

        Console.WriteLine($"Subject: {subject}");
    }
    public override void GetRole()
    {
        Console.WriteLine("I'm a TEACHER in the school");
    }

    public void teach()
    {
        Console.WriteLine("I Teach");
    }
}


class Staff : Person, IWork
{
    public Staff(string name, int age) : base(name, age)
    {
    }
    public override void GetRole()
    {
        Console.WriteLine("I am a staff member.");
    }

    public void work()
    {
        Console.WriteLine("I Belong to school");
    }
}




class Program
{
    static void Main()
    {
        Student student1 = new Student("Gowthami", 21, 101);
        //Student student1 = new Student();
        //student1.Name = "Gowthami";
        //student1.Age = 21;
        //student1.RollNumber = 101;

        Teacher teacher1 = new Teacher("Kural", 27, "Maths");
        //Teacher teacher1 = new Teacher();
        //teacher1.Name = "Kural";
        //teacher1.Age = 27;
        //teacher1.subject = "Maths";

        Staff person1 = new Staff("Office Staff", 35);
        //Staff person1 = new Staff();
        //person1.GetRole();
        //person1.work();
        //Console.WriteLine();
        //Console.WriteLine();

        Console.WriteLine("Staff Details are: ");
        person1.GetRole();
        person1.work();


        Console.WriteLine();
        Console.WriteLine();


        Console.WriteLine("Student Details are ");
        student1.DisplayStudentInfo();
        student1.GetRole();
        student1.study();

        Console.WriteLine();
        Console.WriteLine();



        Console.WriteLine("Teacher Details are: ");
        teacher1.DisplayTeacherInfo();
        teacher1.GetRole();
        teacher1.teach();















    }
}