using System;
using System.Threading.Tasks;

class Program4
{

    static async Task Main()
    {
        try
        {
            await Task.Run(() =>
            {
                throw new Exception("Something went wrong!");
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
    }
}