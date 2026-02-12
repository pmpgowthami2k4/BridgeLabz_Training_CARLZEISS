using System;
using System.Collections.Generic;

namespace GenericQueue
{
    class GenericQueue
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(30); // Duplicate allowed

            Console.WriteLine("Queue Elements After Enqueue:");
            PrintQueue(queue);

            Console.WriteLine($"\nTotal Elements: {queue.Count}");

            Console.WriteLine($"\nPeek (Front Element): {queue.Peek()}");

            Console.WriteLine($"\nContains 20? {queue.Contains(20)}");
            Console.WriteLine($"Contains 100? {queue.Contains(100)}");

            Console.WriteLine($"\nDequeued Element: {queue.Dequeue()}");

            Console.WriteLine("\nQueue After Dequeue:");
            PrintQueue(queue);

            int[] arrayFromQueue = queue.ToArray();
            Console.WriteLine("\nQueue Converted To Array:");
            foreach (int num in arrayFromQueue)
            {
                Console.WriteLine(num);
            }

            int[] copyArray = new int[queue.Count];
            queue.CopyTo(copyArray, 0);

            Console.WriteLine("\nCopied Queue To Another Array:");
            foreach (int num in copyArray)
            {
                Console.WriteLine(num);
            }

            queue.Clear();
            Console.WriteLine($"\nQueue After Clear - Count: {queue.Count}");

            Console.WriteLine($"Is Queue Empty? {queue.Count == 0}");

            Console.ReadKey();
        }

        static void PrintQueue(Queue<int> queue)
        {
            foreach (int item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
