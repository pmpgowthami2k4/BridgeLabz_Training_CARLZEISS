using System;

// ABSTRACT PRODUCTS //

// Chair interface
interface IChair
{
    void SitOn();
}

// Sofa interface
interface ISofa
{
    void Relax();
}

// Coffee Table interface
interface ICoffeeTable
{
    void Use();
}


// CONCRETE PRODUCTS //


// Modern Chair
class ModernChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Sitting on a Modern Chair.");
    }
}

// Victorian Chair
class VictorianChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Sitting on a Victorian Chair.");
    }
}


// Modern Sofa
class ModernSofa : ISofa
{
    public void Relax()
    {
        Console.WriteLine("Relaxing on a Modern Sofa.");
    }
}

// Victorian Sofa
class VictorianSofa : ISofa
{
    public void Relax()
    {
        Console.WriteLine("Relaxing on a Victorian Sofa.");
    }
}


// Modern Coffee Table
class ModernCoffeeTable : ICoffeeTable
{
    public void Use()
    {
        Console.WriteLine("Using a Modern Coffee Table.");
    }
}

// Victorian Coffee Table
class VictorianCoffeeTable : ICoffeeTable
{
    public void Use()
    {
        Console.WriteLine("Using a Victorian Coffee Table.");
    }
}

// ABSTRACT FACTORY //

interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
    ICoffeeTable CreateCoffeeTable();
}


// CONCRETE FACTORIES//


// Modern Furniture Factory
class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ISofa CreateSofa()
    {
        return new ModernSofa();
    }

    public ICoffeeTable CreateCoffeeTable()
    {
        return new ModernCoffeeTable();
    }
}


// Victorian Furniture Factory
class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ISofa CreateSofa()
    {
        return new VictorianSofa();
    }

    public ICoffeeTable CreateCoffeeTable()
    {
        return new VictorianCoffeeTable();
    }
}


// CLIENT CODE//

class abstractfactory
{
    static void Main()
    {
        IFurnitureFactory factory;

        Console.WriteLine("Choose furniture style (Modern / Victorian): ");
        string choice = Console.ReadLine();

        if (choice == "Modern")
        {
            factory = new ModernFurnitureFactory();
        }
        else
        {
            factory = new VictorianFurnitureFactory();
        }

        // Create furniture using factory
        IChair chair = factory.CreateChair();
        ISofa sofa = factory.CreateSofa();
        ICoffeeTable table = factory.CreateCoffeeTable();

        // Use the furniture
        chair.SitOn();
        sofa.Relax();
        table.Use();
    }
}