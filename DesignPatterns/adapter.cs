using System;


// TARGET INTERFACE


// The interface expected by the client
public interface ITarget
{
    string GetRequest();
}


// ADAPTEE


// Existing class with an incompatible interface
public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request from Adaptee.";
    }
}


// ADAPTER


// Adapter converts Adaptee interface into Target interface
public class Adapter : ITarget
{
    private Adaptee adaptee;

    // Constructor receives the adaptee object
    public Adapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    // Convert the request format
    public string GetRequest()
    {
        return "Adapter converts: " + adaptee.GetSpecificRequest();
    }
}


// CLIENT


class adapter
{
    static void Main()
    {
        // Existing incompatible object
        Adaptee adaptee = new Adaptee();

        // Wrap it with adapter
        ITarget target = new Adapter(adaptee);

        // Client calls the expected method
        Console.WriteLine(target.GetRequest());
    }
}
