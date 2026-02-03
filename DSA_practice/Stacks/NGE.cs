public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {

        // stack to keep numbers in decreasing order
        Stack<int> stack = new Stack<int>();

        // map to store: number -> its next greater element
        Dictionary<int, int> map = new Dictionary<int, int>();

        // traverse nums2
        foreach (int num in nums2)
        {

            // while current number is greater than stack top
            while (stack.Count > 0 && num > stack.Peek())
            {
                int smaller = stack.Pop();
                map[smaller] = num;
            }

            // push current number
            stack.Push(num);
        }

        // remaining elements have no greater element
        while (stack.Count > 0)
        {
            map[stack.Pop()] = -1;
        }

        // build result for nums1
        int[] result = new int[nums1.Length];

        for (int i = 0; i < nums1.Length; i++)
        {
            result[i] = map[nums1[i]];
        }

        return result;
    }
}
