using System;
using System.Collections.Generic;

class LongestSubstring
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        int maxLength = LengthOfLongestSubstring(s);
        Console.WriteLine("Length of longest substring without repeating characters: " + maxLength);
    }

    static int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();
        int left = 0, maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char current = s[right];

            if (map.ContainsKey(current) && map[current] >= left)
            {
                left = map[current] + 1;
            }

            map[current] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}
