using System;

// PRODUCT INTERFACE // All products must follow the same interface
interface ITransport
{
    void Deliver();
}

// CONCRETE PRODUCT 1 // Truck implements the Transport interface
class Truck : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering goods by road using a Truck.");
    }
}

// CONCRETE PRODUCT 2 // Ship also implements the Transport interface
class Ship : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering goods by sea using a Ship.");
    }
}


// CREATOR (Factory Class) // This class declares the Factory Method
abstract class Logistics
{
    // Factory Method
    // Subclasses will decide which transport object to create
    public abstract ITransport CreateTransport();

    // Business logic that uses the product created by the factory method
    public void PlanDelivery()
    {
        // Instead of directly creating objects with "new",
        // we call the factory method
        ITransport transport = CreateTransport();

        // Use the created object
        transport.Deliver();
    }
}


// CONCRETE CREATOR 1 // This class creates Truck objects
class RoadLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
}


// CONCRETE CREATOR 2 // This class creates Ship objects
class SeaLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}


// CLIENT CODE // The client works with the creator class without knowing // which exact product will be created
class factorymethod
{
    static void Main()
    {
        Logistics logistics;

        Console.WriteLine("Enter transport type (Road / Sea): ");
        string choice = Console.ReadLine();

        // Decide which factory to use
        if (choice == "Road")
        {
            logistics = new RoadLogistics();
        }
        else
        {
            logistics = new SeaLogistics();
        }

        // Call the method that internally uses the factory method
        logistics.PlanDelivery();
    }
}