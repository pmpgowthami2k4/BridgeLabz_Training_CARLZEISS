using System;
using System.Collections.Generic;

namespace GenericStack
{
    class GenericStackDemo  
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(30); // Duplicate allowed

            Console.WriteLine("Stack Elements After Push:");
            PrintStack(stack);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"\nTotal Elements: {stack.Count}");

            Console.WriteLine($"\nPeek (Top Element): {stack.Peek()}");

            
            Console.WriteLine($"\nContains 20? {stack.Contains(20)}");
            Console.WriteLine($"Contains 100? {stack.Contains(100)}");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"\nPopped Element: {stack.Pop()}");

            Console.WriteLine("\nStack After Pop:");
            PrintStack(stack);
            Console.WriteLine();
            Console.WriteLine();

            int[] arrayFromStack = stack.ToArray();
            Console.WriteLine("\nStack Converted To Array:");
            foreach (int num in arrayFromStack)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();
            Console.WriteLine();

            int[] copyArray = new int[stack.Count];
            stack.CopyTo(copyArray, 0);

            Console.WriteLine("\nCopied Stack To Another Array:");
            foreach (int num in copyArray)
            {
                Console.WriteLine(num);
            }


            stack.Clear();
            Console.WriteLine($"\nStack After Clear - Count: {stack.Count}");

            Console.WriteLine($"Is Stack Empty? {stack.Count == 0}");

            Console.ReadKey();
        }

        static void PrintStack(Stack<int> stack)
        {
            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

