//. Given a list of strings, group them by their length and display each group.

using System;
using System.Collections.Generic;
using System.Linq;

public class groupingquestion6
{
    static void Main()
    {
        List<string> strings = new List<string>
        {
            "Hello",
            "World",
            "C#",
            "Programming",
            "LINQ",
            "Grouping",
           "cat", "bat"
        };

        var result = strings.GroupBy(s => s.Length);

        //foreach (var group in result)
        //{
        //    Console.WriteLine($"Length: {group.Key}");
        //    foreach (var str in group)
        //    {
        //        Console.WriteLine($" - {str}");
        //    }
        //    Console.WriteLine();
        //}

        foreach(var group in result)
        {
            Console.WriteLine($"Length: {group.Key}");
            foreach(var str in group) {
                Console.WriteLine($" - {str}");
            

                   
            }
              
        }
        }
       
    }
