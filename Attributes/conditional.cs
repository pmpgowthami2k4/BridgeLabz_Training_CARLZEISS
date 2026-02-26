

//any line that starts with # is a preprocessor directive. they are processed before the actual compilation of the code. 
// #define must appear before any non-preprocessor code in the file.


//#define HELLO

using System;
using System.Diagnostics;

class Logger
{
    [Conditional("HELLO")]
    public static void Log(string message)
    {
        Console.WriteLine("LOG: " + message);
    }
}

class conditionalProgram
{
    static void Main()
    {
        Console.WriteLine("Application started.");
        Logger.Log("Helloing");
        Console.WriteLine("Main Method Running");
    }
}


