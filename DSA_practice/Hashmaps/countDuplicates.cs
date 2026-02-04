public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {

        HashSet<int> seen = new HashSet<int>();

        foreach (int num in nums)
        {
            // if number already exists 
            if (seen.Contains(num))
                return true;

            // otherwise remember the number
            seen.Add(num);
        }

        return false;
    }
}
