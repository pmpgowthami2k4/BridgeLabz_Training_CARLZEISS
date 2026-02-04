public class Solution
{
    public int EvalRPN(string[] tokens)
    {

        Stack<int> stack = new Stack<int>();

        foreach (string token in tokens)
        {

            // if token is an operator
            if (token == "+" || token == "-" || token == "*" || token == "/")
            {

                int b = stack.Pop();   // second operand
                int a = stack.Pop();   // first operand

                int result = 0;

                if (token == "+") result = a + b;
                else if (token == "-") result = a - b;
                else if (token == "*") result = a * b;
                else result = a / b;   // integer division

                stack.Push(result);
            }
            // if token is a number
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
    }
}
