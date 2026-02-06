using System;
using System.Collections.Generic;

namespace TestResultSystem
{
    // Model
    class TestResult
    {
        public string TestId { get; set; }
        public string MachineId { get; set; }
        public DateTime Timestamp { get; set; }
        public double ResultValue { get; set; }
    }

    class TestResultManager
    {
        private HashSet<string> testIds = new HashSet<string>();
        private Dictionary<string, LinkedList<TestResult>> machineResults =
            new Dictionary<string, LinkedList<TestResult>>();
        private Stack<TestResult> undoStack = new Stack<TestResult>();
        private Queue<TestResult> expiryQueue = new Queue<TestResult>();

        private readonly TimeSpan expiryTime = TimeSpan.FromMinutes(10);

        // Insert test result
        public void Insert(TestResult result)
        {
            // Duplicate check
            if (testIds.Contains(result.TestId))
            {
                Console.WriteLine($" Duplicate TestId ignored: {result.TestId}");
                return;
            }

            testIds.Add(result.TestId);

            if (!machineResults.ContainsKey(result.MachineId))
                machineResults[result.MachineId] = new LinkedList<TestResult>();

            machineResults[result.MachineId].AddLast(result);
            undoStack.Push(result);
            expiryQueue.Enqueue(result);

            Console.WriteLine($"Inserted TestId={result.TestId} for Machine={result.MachineId}");

            RemoveExpired(result.Timestamp);
        }

        // Remove expired results
        private void RemoveExpired(DateTime currentTime)
        {
            while (expiryQueue.Count > 0 &&
                   expiryQueue.Peek().Timestamp < currentTime - expiryTime)
            {
                TestResult expired = expiryQueue.Dequeue();

                testIds.Remove(expired.TestId);
                machineResults[expired.MachineId].Remove(expired);

                Console.WriteLine($" Removed expired TestId={expired.TestId}");
            }
        }

        // Get latest N results for a machine
        public void GetLatestResults(string machineId, int n)
        {
            if (!machineResults.ContainsKey(machineId))
            {
                Console.WriteLine("No records for machine");
                return;
            }

            Console.WriteLine($"\nLatest {n} results for Machine {machineId}:");

            int count = 0;
            var node = machineResults[machineId].Last;

            while (node != null && count < n)
            {
                var r = node.Value;
                Console.WriteLine($"  {r.TestId} | {r.ResultValue}");
                node = node.Previous;
                count++;
            }
        }

        // Undo last insert
        public void UndoLastInsert()
        {
            if (undoStack.Count == 0)
            {
                Console.WriteLine("Nothing to undo");
                return;
            }

            TestResult last = undoStack.Pop();

            testIds.Remove(last.TestId);
            machineResults[last.MachineId].Remove(last);

            Console.WriteLine($"↩ Undo TestId={last.TestId}");
        }
    }

    class Program
    {
        static void Main()
        {
            TestResultManager manager = new TestResultManager();
            DateTime now = DateTime.UtcNow;

            // Dummy data
            manager.Insert(new TestResult { TestId = "T1", MachineId = "M1", Timestamp = now.AddMinutes(-9), ResultValue = 95 });
            manager.Insert(new TestResult { TestId = "T2", MachineId = "M1", Timestamp = now.AddMinutes(-7), ResultValue = 97 });
            manager.Insert(new TestResult { TestId = "T3", MachineId = "M2", Timestamp = now.AddMinutes(-5), ResultValue = 88 });
            manager.Insert(new TestResult { TestId = "T4", MachineId = "M1", Timestamp = now.AddMinutes(-2), ResultValue = 99 });

            // Duplicate test
            manager.Insert(new TestResult { TestId = "T2", MachineId = "M1", Timestamp = now, ResultValue = 100 });

            // Fetch latest results
            manager.GetLatestResults("M1", 2);

            // Undo
            manager.UndoLastInsert();

            // Fetch again
            manager.GetLatestResults("M1", 2);
        }
    }
}


//========OUTPUT========
//Inserted TestId=T1 for Machine=M1
//Inserted TestId=T2 for Machine=M1
//Inserted TestId=T3 for Machine=M2
//Inserted TestId=T4 for Machine=M1
//Duplicate TestId ignored: T2

//Latest 2 results for Machine M1:
//  T4 | 99
//  T2 | 97

//↩ Undo TestId=T4

//Latest 2 results for Machine M1:
//  T2 | 97
//  T1 | 95
