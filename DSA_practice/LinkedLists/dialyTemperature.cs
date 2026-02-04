public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {

        int n = temperatures.Length;
        int[] result = new int[n];

        // stack stores indices
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {

            // while current temperature is higher
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int prevIndex = stack.Pop();
                result[prevIndex] = i - prevIndex;
            }

            // push current index
            stack.Push(i);
        }

        return result;
    }
}
