using System;
using System.Threading;
using System.Threading.Tasks;

//You are building a Payment Processing API.
//1) System receives 100+ payment requests
//2)But you must allow only 3 payments at a time
//4) Remaining requests should wait (not fail)
//5) After one completes → next should start automatically

class PaymentProcessor
{
    private readonly SemaphoreSlim semaphore1 = new SemaphoreSlim(3);

    public async Task ProcessPaymentAsync(int paymentId)
    {
        Console.WriteLine($"Payment {paymentId} waiting");

        await semaphore1.WaitAsync();
        try
        {
            Console.WriteLine($"Processing Payment {paymentId} on Thread {Thread.CurrentThread.ManagedThreadId}");

           
            await Task.Delay(2000);

            Console.WriteLine($"Completed Payment {paymentId}");
        }
        finally
        {
            semaphore1.Release();
        }
    }
}

public class review9
{
    static async Task Main()
    {
        var processor = new PaymentProcessor();
        var tasks = new Task[10];

        for(int i =0; i< 10; i++)
        {
            int id = i + 1;
            tasks[i] = processor.ProcessPaymentAsync(id);
        }

        await Task.WhenAll(tasks);

        Console.WriteLine(" All payments done. ");

    }
}