using System;

class LeftRotateArray
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter the elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Left rotate by 1
        int first = arr[0];
        for (int i = 0; i < n - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[n - 1] = first;

        Console.WriteLine("Array after left rotation by 1:");
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
    }
}
