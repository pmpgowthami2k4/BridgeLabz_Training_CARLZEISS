public class Solution
{
    public int FirstUniqChar(string s)
    {
        Dictionary<char, int> count = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (count.ContainsKey(c))
            {
                count[c]++;
            }
            else
            {
                count[c] = 1;
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (count[s[i]] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}