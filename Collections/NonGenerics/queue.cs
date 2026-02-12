using System;
using System.Collections;

class QueueDemo
{
    static void Main()
    {
        Queue queue = new Queue();

       
        queue.Enqueue(101);
        queue.Enqueue("Hello");
        queue.Enqueue(3.14);
        queue.Enqueue(true);
        queue.Enqueue('A');

        Console.WriteLine("Elements After Enqueue:");
        Display(queue);

        
        Console.WriteLine($"Total Elements in Queue: {queue.Count}");

       
        Console.WriteLine($"First Element: {queue.Peek()}");
        Console.WriteLine($"Count after Peek(): {queue.Count}");


        Console.WriteLine($"Removed Element: {queue.Dequeue()}");
        Console.WriteLine($"Count after Dequeue(): {queue.Count}");

        Console.WriteLine("\nQueue After Dequeue:");
        Display(queue);

       
        Console.WriteLine("Checking Element Existence:");
        Console.WriteLine("Contains 'Hello'? " + queue.Contains("Hello"));
        Console.WriteLine("Contains 500? " + queue.Contains(500));

        queue.Clear();
        Console.WriteLine($"\nAfter Clear(), Total Elements: {queue.Count}");

        Console.ReadKey();
    }

    static void Display(Queue queue)
    {
        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }
    }
}
