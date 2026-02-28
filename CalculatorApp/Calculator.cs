using System;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;   // Minimum code to pass
        }

        public int Subtract(int a, int b)
        {
            if (a < b)
            throw new ArgumentException("a must be greater than b");

                 return a - b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Denominator cannot be zero");

            return a / b;
        }
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
    

}