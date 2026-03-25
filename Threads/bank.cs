//Bank Account Balance Check and Deposit using Multi-Threading(Thread creation,
//Concurrent execution, Shared resource)
//1.A bank account has an initial balance of 1000.
//2. One thread will deposit money into the account.
//3. Another thread will check the balance repeatedly.
//4. Both should run concurrently using threads, so balance updates can be seen while 
//deposits are happening.


using System;
using System.Threading;

class BankAccount
{
    private int balance = 1000;
    private readonly object lock1 = new object();

    public void Deposit(int amount)
    {
        lock (lock1)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");
        }
    }

    public int GetBalance()
    {
        lock (lock1)
        {
            return balance;
        }
    }
}

class bank
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        // Thread 1 Deposit money
        Thread depositThread = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                account.Deposit(200);
                Thread.Sleep(1000);
            }
        });

        // Thread 2 Check balance
        Thread checkThread = new Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Checked Balance: {account.GetBalance()}");
                Thread.Sleep(500);
            }
        });

        depositThread.Start();
        checkThread.Start();

        depositThread.Join();
        checkThread.Join();

        Console.WriteLine("Final Balance: " + account.GetBalance());
    }
}