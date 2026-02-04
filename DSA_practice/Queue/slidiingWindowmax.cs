public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {

        int n = nums.Length;
        int[] result = new int[n - k + 1];

        // stores indices, not values
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < n; i++)
        {

            // remove indices that are out of the window
            if (deque.Count > 0 && deque.First.Value <= i - k)
            {
                deque.RemoveFirst();
            }

            // remove smaller elements from the back
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
            {
                deque.RemoveLast();
            }

            // add current index
            deque.AddLast(i);

            // record answer once window is ready
            if (i >= k - 1)
            {
                result[i - k + 1] = nums[deque.First.Value];
            }
        }

        return result;
    }
}
