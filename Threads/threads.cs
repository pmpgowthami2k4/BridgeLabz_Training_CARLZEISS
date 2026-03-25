using System;
using System.Threading;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

//        Thread t = new Thread(PrintNumbers);
//        t.Start();

//        Console.WriteLine("Main thread continues...");
//    }

//    static void PrintNumbers()
//    {
//        Console.WriteLine($"Worker Thread: {Thread.CurrentThread.ManagedThreadId}");

//        for (int i = 1; i <= 5; i++)
//        {
//            Console.WriteLine(i);
//            Thread.Sleep(500);
//        }
//    }
//}

//////////////////////////////////////////THREAD POOL
//using System;
//using System.Threading;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

//        ThreadPool.QueueUserWorkItem(PrintNumbers);

//        Console.WriteLine("Main thread continues...");

//        Console.ReadLine(); // Prevent app from exiting early
//    }

//    static void PrintNumbers(object state)
//    {
//        Console.WriteLine($"ThreadPool Thread: {Thread.CurrentThread.ManagedThreadId}");

//        for (int i = 1; i <= 5; i++)
//        {
//            Console.WriteLine(i);
//            Thread.Sleep(500);
//        }
//    }
//}

//////////////////////////////////////////TASKS
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

//        Task task = Task.Run(() =>
//        {
//            Console.WriteLine($"Task Thread: {Thread.CurrentThread.ManagedThreadId}");

//            for (int i = 1; i <= 5; i++)
//            {
//                Console.WriteLine(i);
//                Thread.Sleep(500);
//            }
//        });

//        Console.WriteLine("Main thread continues...");

//        task.Wait(); // Wait for task to complete
//    }
//}

//////////////////////////////////////////ASYNC/AWAIT           
using System;
using System.Threading.Tasks;

//class Program
//{
//    static async Task Main()
//    {
//        Console.WriteLine("Start");

//        int result = await CalculateAsync();

//        Console.WriteLine($"Result: {result}");
//        Console.WriteLine("End");
//    }

//    static async Task<int> CalculateAsync()
//    {
//        await Task.Delay(2000); // simulate work
//        return 100;
//    }
//}

//////////////////////////////////////////PARALLEL ASYNC TASKS
//class Program
//{
//    static async Task Main()
//    {
//        var t1 = GetDataAsync(1);
//        var t2 = GetDataAsync(2);

//        var results = await Task.WhenAll(t1, t2);

//        Console.WriteLine($"Results: {results[0]}, {results[1]}");
//    }

//    static async Task<int> GetDataAsync(int id)
//    {
//        await Task.Delay(2000);
//        return id * 10;
//    }
//}

//Real Parallel Async Work
//using System;
//using System.Threading.Tasks;

//class Program
//{
//    static async Task Main()
//    {
//        var t1 = GetDataAsync(1);
//        var t2 = GetDataAsync(2);

//        var results = await Task.WhenAll(t1, t2);

//        Console.WriteLine($"Results: {results[0]}, {results[1]}");
//    }

//    static async Task<int> GetDataAsync(int id)
//    {
//        await Task.Delay(2000);
//        return id * 10;
//    }
//}


//////////////////////////////////////////RACE CONDITION
//using System;
//using System.Threading.Tasks;

//class Program
//{
//    static int count = 0;

//    static async Task Main()
//    {
//        var tasks = new Task[1000];

//        for (int i = 0; i < 1000; i++)
//        {
//            tasks[i] = Task.Run(() =>
//            {             

//                count++; // ❌ NOT safe}

//            });
//        }

//        await Task.WhenAll(tasks);

//        Console.WriteLine($"Final Count: {count}");
//    }
//}


//////////////////////////////////////////LOCKING

//using System;
//using System.Threading.Tasks;

//class Program
//{
//    static int count = 0;
//    static object _lock = new object();

//    static async Task Main()
//    {
//        var tasks = new Task[1000];

//        for (int i = 0; i < 1000; i++)
//        {
//            tasks[i] = Task.Run(() =>
//            {
//                lock (_lock)
//                {
//                    count++; //  safe
//                }
//            });
//        }

//        await Task.WhenAll(tasks);

//        Console.WriteLine($"Final Count: {count}");
//    }
//}

////////////////////////////////////////Blocking Threads

//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class Program
//{
//    static async Task Main()
//    {
//        var tasks = new Task[20];

//        for (int i = 0; i < 20; i++)
//        {
//            int id = i;

//            tasks[i] = Task.Run(() =>
//            {
//                Console.WriteLine($"Start {id} - Thread {Thread.CurrentThread.ManagedThreadId}");

//                Thread.Sleep(3000); // ❌ blocking

//                Console.WriteLine($"End {id}");
//            });
//        }

//        await Task.WhenAll(tasks);
//    }
//}

//////////////////////NON BLOCKING
//using System;
//using System.Threading.Tasks;

//class Program
//{
//    static async Task Main()
//    {
//        var tasks = new Task[20];

//        for (int i = 0; i < 20; i++)
//        {
//            int id = i;

//            tasks[i] = Task.Run(async () =>
//            {
//                Console.WriteLine($"Start {id}");

//                await Task.Delay(3000); // ✅ non-blocking

//                Console.WriteLine($"End {id}");
//            });
//        }

//        await Task.WhenAll(tasks);
//    }
//}

//NORMAL DICTIONARY
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//class Program
//{
//    static Dictionary<int, int> dict = new Dictionary<int, int>();

//    static async Task Main()
//    {
//        var tasks = new Task[1000];

//        for (int i = 0; i < 1000; i++)
//        {
//            int id = i;

//            tasks[i] = Task.Run(() =>
//            {
//                dict[id] = id; // ❌ NOT thread-safe
//            });
//        }

//        await Task.WhenAll(tasks);

//        Console.WriteLine($"Count: {dict.Count}");
//    }
//}

///////////////////////////////CONCURRENT DICTIONARY     
////using System;
//using System.Collections.Concurrent;
//using System.Threading.Tasks;

//class Program
//{
//    static ConcurrentDictionary<int, int> dict = new();

//    static async Task Main()
//    {
//        var tasks = new Task[1000];

//        for (int i = 0; i < 1000; i++)
//        {
//            int id = i;

//            tasks[i] = Task.Run(() =>
//            {
//                dict.TryAdd(id, id); // ✅ thread-safe
//            });
//        }

//        await Task.WhenAll(tasks);

//        Console.WriteLine($"Count: {dict.Count}");
//    }
//}


///////////////////// NORML LOOP
//using System;
//using System.Diagnostics;

//class Program
//{
//    static void Main()
//    {
//        var sw = Stopwatch.StartNew();

//        for (int i = 0; i < 100000; i++)
//        {
//            DoWork(i);
//        }

//        sw.Stop();
//        Console.WriteLine($"Normal Loop Time: {sw.ElapsedMilliseconds} ms");
//    }

//    static void DoWork(int i)
//    {
//        double result = Math.Sqrt(i) * Math.Pow(i, 2);
//    }
//}

////////////////////////////Parallel.For
///
//using System;
//using System.Diagnostics;
//using System.Threading.Tasks;

//class Program
//{
//    static void Main()
//    {
//        var sw = Stopwatch.StartNew();

//        Parallel.For(0, 100000, i =>
//        {
//            DoWork(i);
//        });

//        sw.Stop();
//        Console.WriteLine($"Parallel Time: {sw.ElapsedMilliseconds} ms");
//    }

//    static void DoWork(int i)
//    {
//        double result = Math.Sqrt(i) * Math.Pow(i, 2);
//    }
//}

/////////////////////BASIC CANCELLATION
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var cts = new CancellationTokenSource();

        //cts.CancelAfter(3000);

        var task = DoWorkAsync(cts.Token);

        // Cancel after 3 seconds
        await Task.Delay(3000);
        cts.Cancel();

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task was cancelled!");
        }
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Working {i}");
            await Task.Delay(1000);
        }
    }
}