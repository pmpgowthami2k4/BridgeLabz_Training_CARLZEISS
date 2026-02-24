using System;
using System.Collections.Generic;
using System.Text;

class quantifier
{
    static void Main()
    {
        List<int> nums = new List<int> { 2, 4, -6, 8, 10 };

        bool hasneg = nums.Any(n => n < 0);
        bool allpos = nums.All(n => n > 0);

        Console.WriteLine($"Any negativa numbers?=={hasneg}");
        Console.WriteLine($"All positive numbers?=={allpos}");
    }
}
