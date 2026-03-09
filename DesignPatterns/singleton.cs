using System;

public class Singleton
{
    private static Singleton instance; //pvt static variable to hold the single instance of the class

    // Private constructor prevents object creation from outside
    private Singleton()
    {
        Console.WriteLine("Singleton Instance Created");
    }

    // Public method to access the instance
    public static Singleton GetInstance()
    {
        if (instance == null) //lazy initialization
        {
            instance = new Singleton();
        }
        return instance;
    }

    public void DisplayMessage()
    {
        Console.WriteLine("Hello from Singleton");
    }
}

class singleton
{
    static void Main()
    {
        Singleton obj1 = Singleton.GetInstance();
        Singleton obj2 = Singleton.GetInstance();

        obj1.DisplayMessage();

        Console.WriteLine(obj1 == obj2); // True
    }
}
