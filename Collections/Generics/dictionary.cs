using System;
using System.Collections.Generic;
using System.Linq;

class Dictionarydemo
{
    static void Main()
    {
        Dictionary<string, string> countries = new Dictionary<string, string>
        {
            { "UK", "United Kingdom" },
            { "USA", "United States of America" },
            { "IND", "India" }
        };

        Console.WriteLine("Initial Dictionary:");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();

        countries.Add("PAK", "Pakistan");

        countries["SL"] = "Sri Lanka";

        Console.WriteLine("After Add() and Indexer Add:");
        Display(countries); 
        Console.WriteLine();
        Console.WriteLine();

        countries["USA"] = "USA Updated";

        Console.WriteLine(" After Updating USA:");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(" Accessing Specific Key:");
        Console.WriteLine("IND → " + countries["IND"]);

        Console.WriteLine("Iterating using foreach:");
        foreach (KeyValuePair<string, string> item in countries)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Iterating using for loop:");
        for (int i = 0; i < countries.Count; i++)
        {
            string key = countries.Keys.ElementAt(i);
            string value = countries[key];
            Console.WriteLine($"Key: {key}, Value: {value}");
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("ContainsKey Checks:");
        Console.WriteLine("ContainsKey 'USA'? " + countries.ContainsKey("USA"));
        Console.WriteLine("ContainsKey 'NZ'? " + countries.ContainsKey("NZ"));
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("ContainsValue Checks:");
        Console.WriteLine("ContainsValue 'India'? " + countries.ContainsValue("India"));
        Console.WriteLine("ContainsValue 'Nepal'? " + countries.ContainsValue("Nepal"));
        Console.WriteLine();
        Console.WriteLine();

        if (countries.ContainsKey("PAK"))
        {
            countries.Remove("PAK");
        }

        Console.WriteLine("\nAfter Removing 'PAK':");
        Display(countries); 
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("\nTotal Elements: " + countries.Count);

        countries.Clear();
        Console.WriteLine("After Clear, Count: " + countries.Count);

        Console.ReadKey();
    }

    static void Display(Dictionary<string, string> dict)
    {
        foreach (var item in dict)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}
