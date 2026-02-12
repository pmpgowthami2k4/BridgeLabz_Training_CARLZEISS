using System;
using System.Collections.Generic;

class ListDemo
{
    static void Main()
    {
        List<string> countries = new List<string>
        {
            "INDIA",
            "USA",
            "UK"
        };

        Console.WriteLine("Initial List:");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();



        
        countries.Add("JAPAN");

        
        List<string> newCountries = new List<string>
        {
            "CANADA",
            "AUSTRALIA"
        };
        countries.AddRange(newCountries);

        Console.WriteLine("After Add & AddRange:");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine($"First Element (Index 0): {countries[0]}");

        Console.WriteLine("Access using for loop:");
        for (int i = 0; i < countries.Count; i++)
        {
            Console.WriteLine(countries[i]);
        }
        Console.WriteLine();
        Console.WriteLine();

        countries.Insert(1, "CHINA");

        countries.InsertRange(2, new List<string> { "GERMANY", "FRANCE" });

        Console.WriteLine("After Insert & InsertRange:");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();



        Console.WriteLine("\n6️⃣ Contains 'USA'? " + countries.Contains("USA"));

        Console.WriteLine("Exists country starting with 'A'? " +
                          countries.Exists(x => x.StartsWith("A")));

        Console.WriteLine("Find first country starting with 'U': " +
                          countries.Find(x => x.StartsWith("U")));

        Console.WriteLine("\nFindAll countries length > 5:");
        var longNames = countries.FindAll(x => x.Length > 5);
        Display(longNames);

        Console.WriteLine("Index of USA: " +
                          countries.FindIndex(x => x == "USA"));

        countries.Remove("USA");

        countries.RemoveAt(0);

        countries.RemoveAll(x => x.Length < 4);

        Console.WriteLine("After Remove operations:");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();

        if (countries.Count >= 2)
        {
            countries.RemoveRange(0, 2);
        }

        Console.WriteLine("After RemoveRange:");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();

        countries.Sort();
        Console.WriteLine("After Sort (Ascending):");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();

        countries.Reverse();
        Console.WriteLine("After Reverse (Descending):");
        Display(countries);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("\nTotal Elements: " + countries.Count);

        countries.Clear();
        Console.WriteLine("After Clear, Count: " + countries.Count);

        Console.ReadKey();
    }

    static void Display(List<string> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
