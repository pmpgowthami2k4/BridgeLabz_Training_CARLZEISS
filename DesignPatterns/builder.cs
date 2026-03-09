using System;
using System.Collections.Generic;


// PRODUCT


// The object that will be constructed step-by-step
public class House
{
    private List<string> parts = new List<string>();

    // Method to add parts to the house
    public void AddPart(string part)
    {
        parts.Add(part);
    }

    // Display the house components
    public void ShowHouse()
    {
        Console.WriteLine("House Parts:");
        foreach (var part in parts)
        {
            Console.WriteLine("- " + part);
        }
    }
}


// BUILDER INTERFACE


// Defines the building steps
public interface IHouseBuilder
{
    void BuildWalls();
    void BuildDoor();
    void BuildWindows();
    void BuildRoof();
    House GetHouse();
}


// CONCRETE BUILDER


// Implements the building steps
public class ConcreteHouseBuilder : IHouseBuilder
{
    private House house = new House();

    public void BuildWalls()
    {
        house.AddPart("Walls built");
    }

    public void BuildDoor()
    {
        house.AddPart("Door installed");
    }

    public void BuildWindows()
    {
        house.AddPart("Windows installed");
    }

    public void BuildRoof()
    {
        house.AddPart("Roof constructed");
    }

    // Returns the final product
    public House GetHouse()
    {
        return house;
    }
}


// DIRECTOR


// Controls the order of building steps
public class HouseDirector
{
    public void ConstructHouse(IHouseBuilder builder)
    {
        builder.BuildWalls();
        builder.BuildDoor();
        builder.BuildWindows();
        builder.BuildRoof();
    }
}


// CLIENT


class builder

{
    static void Main()
    {
        // Create builder
        IHouseBuilder builder = new ConcreteHouseBuilder();

        // Create director
        HouseDirector director = new HouseDirector();

        // Director builds the house using the builder
        director.ConstructHouse(builder);

        // Get the final product
        House house = builder.GetHouse();

        // Display the built house
        house.ShowHouse();
    }
}