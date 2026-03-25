using System;
using System.Threading;
using System.Threading.Tasks;

class Program2
{
    static object lockA = new object();
    static object lockB = new object();

    static void Main()
    {
        var t1 = Task.Run(() =>
        {
            lock (lockA)
            {
                Thread.Sleep(100); // simulate work

                lock (lockB)
                {
                    Console.WriteLine("Thread 1 done");
                }
            }
        });

        var t2 = Task.Run(() =>
        {
            lock (lockB)
            {
                Thread.Sleep(100);

                lock (lockA)
                {
                    Console.WriteLine("Thread 2 done");
                }
            }
        });

        Task.WaitAll(t1, t2);
    }
}


//Ensure same order everywhere to prevent deadlock



/////////////////ASYNCHRONOUS DEADLOCKusing System;
//using System.Threading.Tasks;

class Program3
{
    static void Main()
    {
        var result = GetDataAsync().Result; // ❌

        Console.WriteLine(result);
    }

    static async Task<string> GetDataAsync()
    {
        await Task.Delay(1000);
        return "Done";
    }
}

//.Result blocks thread
//Async method tries to resume on same thread
//That thread is blocked




//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class PaymentProcessor
//{
//    // Allow only 3 payments at a time
//    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(3);

//    public async Task ProcessPaymentAsync(int paymentId)
//    {
//        Console.WriteLine($"Payment {paymentId} waiting...");

//        await _semaphore.WaitAsync(); // wait for slot

//        try
//        {
//            Console.WriteLine($"Processing Payment {paymentId} on Thread {Thread.CurrentThread.ManagedThreadId}");

//            // Simulate payment processing (DB/API call)
//            await Task.Delay(2000);

//            Console.WriteLine($"Completed Payment {paymentId}");
//        }
//        finally
//        {
//            _semaphore.Release(); // free slot for next request
//        }
//    }
//}

//class Program
//{
//    static async Task Main()
//    {
//        var processor = new PaymentProcessor();

//        var tasks = new Task[10]; // simulate 10 incoming requests

//        for (int i = 0; i < 10; i++)
//        {
//            int id = i + 1;
//            tasks[i] = processor.ProcessPaymentAsync(id);
//        }

//        await Task.WhenAll(tasks);

//        Console.WriteLine("All payments processed!");
//    }
//}