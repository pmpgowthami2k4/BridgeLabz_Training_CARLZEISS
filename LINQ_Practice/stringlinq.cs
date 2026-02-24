//String Operations with LINQ
//Given a list of strings, write a LINQ query to nd all strings that start with the letter ‘A’ and have a
//length greater than 5.


using System;
using System.Collections.Generic;
using System.Text;

class stringlinq
{
    static void Main()
    {
        List<string> names = new List<string>()
        {
            "Alice",
            "Bob",
            "ArunimaS",
            "Anjali",
            "Ravi",
            "Priya"
        };

        var Results = names.Where(s => s.StartsWith("A") && s.Length > 5);

        Console.WriteLine("Names that start with A");
        foreach(var name in Results)
        {
            Console.WriteLine(name);
        }
    }
}