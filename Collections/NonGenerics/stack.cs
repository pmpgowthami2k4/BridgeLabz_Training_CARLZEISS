using System;
using System.Collections;

class StackDemo
{
    static void Main()
    {
        Stack stack = new Stack();
        Console.WriteLine("Created Stack");

        stack.Push(10);
        stack.Push("Hello");
        stack.Push(3.14);
        stack.Push(true);
        stack.Push('A');

        Console.WriteLine("Elements after pushing: ");
        Display(stack);

        Console.WriteLine($"Total Elements: {stack.Count}");

        Console.WriteLine($"\nTop Element using Peek(): {stack.Peek()}");
        Console.WriteLine($"Count after Peek(): {stack.Count}");

        Console.WriteLine($"\nRemoved Element using Pop(): {stack.Pop()}");
        Console.WriteLine($"Count after Pop(): {stack.Count}");

        Console.WriteLine("\nStack After Pop:");
        Display(stack);

        Console.WriteLine("\nChecking Element Existence:");
        Console.WriteLine("Contains 'Hello'? " + stack.Contains("Hello"));
        Console.WriteLine("Contains 100? " + stack.Contains(100));

        stack.Clear();
        Console.WriteLine($"\nAfter Clear(), Total Elements: {stack.Count}");

        Console.ReadKey();
    }

    static void Display(Stack stack)
    {
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}
