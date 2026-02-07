using System;

class Ranking
{
    static void SelectionSort(int[] scores)
    {
        int n = scores.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int minInd = 0;
            for (int j = 1; j <= i; j++)
            {
                if (scores[j] < scores[minInd])
                {
                    minInd = j;
                }
            }
            int temp = scores[minInd];
            scores[minInd] = scores[i];
            scores[i] = temp;
        }
    }

    static void Main()
    {
        int[] confidenceScores = { 78, 65, 90, 55, 88 };

        Console.WriteLine("Input Score:");
        Console.WriteLine(string.Join(", ", confidenceScores));

        SelectionSort(confidenceScores);

        Console.WriteLine("\nAfter Sorting :");
        Console.WriteLine(string.Join(", ", confidenceScores));
    }
}