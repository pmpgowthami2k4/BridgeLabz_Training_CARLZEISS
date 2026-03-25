using System;
using System.Threading.Tasks;

class Program5
{
    static void Main()
    {
        var t1 = Task.Run(() => throw new Exception("Error 1"));
        var t2 = Task.Run(() => throw new Exception("Error 2"));

        try
        {
            Task.WaitAll(t1, t2);
        }
        catch (AggregateException ex)
        {
            foreach (var e in ex.InnerExceptions)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}