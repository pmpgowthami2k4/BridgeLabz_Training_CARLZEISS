using System;

namespace ExceptionFullDemo
{
    // Custom Exception
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }

        public InvalidAgeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" EXCEPTION DEMO PROGRAM \n");

            // TCF
            try
            {
                Console.Write("Enter first number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter second number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                int result = DivideNumbers(num1, num2);
                Console.WriteLine($"Result = {result}");

                Console.Write("\nEnter your age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                ValidateAge(age);
            }

            // Multiple Catch Blocks
            catch (FormatException ex)
            {
                Console.WriteLine("Format Exception: Please enter valid numbers.");
                Console.WriteLine("Message: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divide By Zero Exception: Cannot divide by zero.");
                Console.WriteLine("Message: " + ex.Message);
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("Custom Exception Occurred!");
                Console.WriteLine("Message: " + ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
            }

            finally
            {
                
                Console.WriteLine("\nFinally Block Executed (Cleanup Code)");
            }

            //TF
            Console.WriteLine("\nTRY-FINALLY Example ");

            try
            {
                Console.WriteLine("Inside Try Block");
                int x = 10;
                int y = 0;
                int z = x / y; // Will throw exception
            }
            finally
            {
                Console.WriteLine("Finally runs even if exception occurs.");
            }

            Console.ReadKey();
        }

        // Method to demonstrate built-in exception
        static int DivideNumbers(int a, int b)
        {
            return a / b;
        }

        // Method to demonstrate custom + inner exception
        static void ValidateAge(int age)
        {
            try
            {
                if (age < 18)
                {
                    throw new Exception("Age is below 18.");
                }

                Console.WriteLine("Age is valid.");
            }
            catch (Exception ex)
            {
                // Wrapping original exception inside custom exception
                throw new InvalidAgeException("Invalid Age Provided!", ex);
            }
        }
    }
}
