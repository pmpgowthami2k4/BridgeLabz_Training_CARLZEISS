using System;
using System.Collections.Generic;

namespace SuperDelegateDemo
{
    // 1 Custom Delegate
    public delegate void MyDelegate(string message);

    // 2️ Delegate with Return Type
    public delegate int MathDelegate(int x, int y);

    // 3️ Delegate with out parameter
    public delegate void OutDelegate(out int number);

    class SuperDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Single Cast Delegate =====");
            MyDelegate del1 = ShowMessage;
            del1("Hello from Single Cast Delegate");

            Console.WriteLine("\n===== Multicast Delegate =====");
            MyDelegate multi = ShowMessage;
            multi += ShowAnotherMessage;
            multi("Hello from Multicast Delegate");

            Console.WriteLine("\n===== Delegate with Return Type =====");
            MathDelegate math = Add;
            math += Multiply;   // Multicast with return type
            int result = math(5, 2);   // Only last method result returned
            Console.WriteLine("Returned Value (Last Method): " + result);

            Console.WriteLine("\n=====  Delegate with OUT Parameter =====");
            OutDelegate outDel = SetOne;
            outDel += SetTwo;
            int number;
            outDel(out number);   // Last method value stored
            Console.WriteLine("Final Out Value: " + number);

            Console.WriteLine("\n===== Anonymous Method =====");
            MyDelegate anon = delegate (string msg)
            {
                Console.WriteLine("Anonymous Method Says: " + msg);
            };
            anon("Hello Anonymous");

            Console.WriteLine("\n===== Lambda Expression =====");
            MyDelegate lambda = (msg) =>
            {
                Console.WriteLine("Lambda Says: " + msg);
            };
            lambda("Hello Lambda");

            Console.WriteLine("\n===== Generic Delegates =====");

            // Func (returns value)
            Func<int, int, int> func = (a, b) => a + b;
            Console.WriteLine("Func Result: " + func(10, 20));

            // Action (returns nothing)
            Action<string> action = (name) =>
            {
                Console.WriteLine("Action Says Hello " + name);
            };
            action("Gowthami");

            // Predicate (returns bool)
            Predicate<int> isEven = (n) => n % 2 == 0;
            Console.WriteLine("Is 10 Even? " + isEven(10));

            Console.WriteLine("\n===== Delegate as Parameter (Callback) =====");
            DoWork("Callback Test", ShowMessage);

            Console.WriteLine("\n===== Closure Example =====");
            Func<int> counter = CreateCounter();
            Console.WriteLine(counter());
            Console.WriteLine(counter());
            Console.WriteLine(counter());

            Console.ReadKey();
        }

        // Methods for delegates
        static void ShowMessage(string message)
        {
            Console.WriteLine("ShowMessage: " + message);
        }

        static void ShowAnotherMessage(string message)
        {
            Console.WriteLine("ShowAnotherMessage: " + message);
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add Executed");
            return x + y;
        }

        static int Multiply(int x, int y)
        {
            Console.WriteLine("Multiply Executed");
            return x * y;
        }

        static void SetOne(out int number)
        {
            Console.WriteLine("SetOne Executed");
            number = 1;
        }

        static void SetTwo(out int number)
        {
            Console.WriteLine("SetTwo Executed");
            number = 2;
        }

        // Callback example
        static void DoWork(string msg, MyDelegate del)
        {
            Console.WriteLine("Doing some work...");
            del(msg);
        }

        // Closure Example
        static Func<int> CreateCounter()
        {
            int count = 0;

            return () =>
            {
                count++;
                return count;
            };
        }
    }
}
