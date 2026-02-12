using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

class HashTable
{
    static void Main()
    {
        Hashtable ht = new Hashtable();

        ht.Add("E.Id", 1001);
        ht.Add("Name", "Tom");
        ht.Add("Salary", 100000);
        Display(ht);

        ht["Location"] = "Mumbai";
        Display(ht);

        ht["Salary"] = 120000;
        Display(ht);

        Console.WriteLine("Name is " + ht["Name"]);
        Console.WriteLine("Salary is " + ht["Salary"]);

        foreach (DictionaryEntry item in ht)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        Console.WriteLine("Contains Name: ?" + ht.Contains("Name"));
        Console.WriteLine("Contains 'Dept': ?" + ht.ContainsKey("Dept"));

        Console.WriteLine("ContainsValue 5000? " + ht.ContainsValue(5000));
        Console.WriteLine("ContainsValue 'Delhi'? " + ht.ContainsValue("Delhi"));

        Console.WriteLine("Total Elements" + ht.Count);


        ht.Remove("Location");
        Console.WriteLine("\nAfter Removing 'Location'");
        Display(ht);

        Console.WriteLine("Creating using Initializer");

        Hashtable ht2 = new Hashtable()
        {
            { "Country", "India" },
            { "Capital", "Delhi" },
            { "Population", 1400000000 }
        };


        foreach (DictionaryEntry item in ht2)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }




        ht2["Currency"] = "INR";
        ht2["Capital"] = "New Delhi";

        Display(ht2);

        Console.ReadKey();



    }

    static void Display(Hashtable ht)
    {
        Console.WriteLine("\n Displaying Hashtable");
        foreach (DictionaryEntry item in ht)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}