using System;
using System.Collections.Generic;
using System.Linq;

class sorting1
{
    static void Main()
    {
        List<int> numbers = new List<int> { 10, 45, 23, 89, 12, 67 };

        var sortedNumbers = numbers.OrderByDescending(n => n);

        Console.WriteLine("Nums in desc order");
        foreach(var number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
        
        
        }