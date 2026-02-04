

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {

        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int needed = target - nums[i];

            if (map.ContainsKey(needed))
            {
                return new int[] { map[needed], i };
            }
            map[nums[i]] = i;
        }

        return new int[] { };

    }
}