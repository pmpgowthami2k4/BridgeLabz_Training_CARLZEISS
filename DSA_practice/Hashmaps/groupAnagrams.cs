public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {

        Dictionary<string, List<string>> map =
            new Dictionary<string, List<string>>();

        foreach (string word in strs)
        {

            // convert word to char array and sort it
            char[] chars = word.ToCharArray();
            Array.Sort(chars);

            // sorted string becomes the key
            string key = new string(chars);

            // if key not present, create a new list
            if (!map.ContainsKey(key))
            {
                map[key] = new List<string>();
            }

            // add original word to its group
            map[key].Add(word);
        }

        // return all grouped values
        return new List<IList<string>>(map.Values);
    }
}
