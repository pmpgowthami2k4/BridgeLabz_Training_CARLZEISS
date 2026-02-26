using System;
using System.Collections.Generic;
using System.Text;

class Calculator
{
    [Obsolete("Use Old Add is removed " /*, true */)]
    public void OldAdd(int a, int b)
    {
        Console.WriteLine("Old Add: " + (a + b));
    }

    public void NewAdd(int a, int b)
    {
        Console.WriteLine("New Add: " + (a + b));
    }

}

class obsoleteProgram
{
    static void Main()
    {
        Calculator calc = new Calculator();
        calc.OldAdd(2, 3);
    }
}