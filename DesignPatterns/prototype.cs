using System;

// PROTOTYPE INTERFACE 

// This interface declares the Clone method
public interface IPrototype
{
    IPrototype Clone();
}


// CONCRETE PROTOTYPE    


public class Person : IPrototype
{
    public string Name;
    public int Age;

    // Constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Clone method creates a copy of the object
    public IPrototype Clone()
    {
        // MemberwiseClone() creates a shallow copy
        return (IPrototype)this.MemberwiseClone();
    }

    public void Display()
    {
        Console.WriteLine("Name: " + Name + " | Age: " + Age);
    }
}

// CLIENT CODE         

class prototype
{
    static void Main()
    {
        // Create original object
        Person p1 = new Person("Alice", 25);

        Console.WriteLine("Original Object:");
        p1.Display();

        // Clone the object
        Person p2 = (Person)p1.Clone();

        Console.WriteLine("Cloned Object:");
        p2.Display();

        // Modify cloned object
        p2.Name = "Bob";

        Console.WriteLine("After modifying clone:");

        Console.WriteLine("Original Object:");
        p1.Display();

        Console.WriteLine("Cloned Object:");
        p2.Display();
    }
}
