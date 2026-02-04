public class Solution
{
    public bool IsAnagram(string s, string t)
    {

        if (s.Length != t.Length)
        {
            return false;
        }

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

        foreach (char c in t)
        {
            if (!count.ContainsKey(c))
            {
                return false;
            }
            count[c]--;

            if (count[c] == 0)
            {
                count.Remove(c);
            }

        }

        return count.Count == 0;



    }
}