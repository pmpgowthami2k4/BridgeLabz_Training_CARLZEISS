using System;
using System.Collections;

class SortedListDemo
{
    static void Main()
    {
        
        SortedList sortedList = new SortedList();
        Console.WriteLine("SortedList Created");

        sortedList.Add(3, "Three");
        sortedList.Add(1, "One");
        sortedList.Add(5, "Five");
        sortedList.Add(2, "Two");
        sortedList.Add(4, "Four");

        Console.WriteLine("After Adding Elements :");
        Display(sortedList);

        Console.WriteLine($"Total Elements: {sortedList.Count}");

        Console.WriteLine("Access Using Key:");
        Console.WriteLine($"Key 1 → {sortedList[1]}");
        Console.WriteLine($"Key 3 → {sortedList[3]}");

        Console.WriteLine("Access Using Index:");
        Console.WriteLine($"Index 0 → {sortedList.GetByIndex(0)}");
        Console.WriteLine($"Index 2 → {sortedList.GetByIndex(2)}");

        Console.WriteLine("Iterate Using For Loop:");
        for (int i = 0; i < sortedList.Count; i++)
        {
            Console.WriteLine($"Key: {sortedList.GetKey(i)}, Value: {sortedList.GetByIndex(i)}");
        }

        Console.WriteLine("Iterate Using Foreach:");
        foreach (DictionaryEntry item in sortedList)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        Console.WriteLine("Checking Key Existence:");
        Console.WriteLine("ContainsKey 2? " + sortedList.ContainsKey(2));
        Console.WriteLine("ContainsKey 10? " + sortedList.ContainsKey(10));

        Console.WriteLine("Checking Value Existence:");
        Console.WriteLine("ContainsValue 'Five'? " + sortedList.ContainsValue("Five"));
        Console.WriteLine("ContainsValue 'Ten'? " + sortedList.ContainsValue("Ten"));

        sortedList.Remove(5);
        Console.WriteLine("After Removing Key 5:");
        Display(sortedList);

        sortedList.RemoveAt(0);
        Console.WriteLine(" After Removing Element at Index 0:");
        Display(sortedList);

        sortedList.Clear();
        Console.WriteLine($"After Clear(), Total Elements: {sortedList.Count}");

        Console.ReadKey();
    }

 
    static void Display(SortedList sortedList)
    {
        foreach (DictionaryEntry item in sortedList)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}

