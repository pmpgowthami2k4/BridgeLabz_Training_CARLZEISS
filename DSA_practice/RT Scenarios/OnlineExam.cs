//3.Real - Time Online Exam Monitoring Question Students submit answers continuously: (studentId, timestamp)
//Requirements: Detect if a student submits >10 answers in 1 minute
//Undo last submission (invigilator mistake)
//Auto-cleanup old submissions

using System;
using System.Collections.Generic;

namespace OnlineExamMonitoring
{
    class Submission
    {
        public string StudentId;
        public DateTime Timestamp;
    }

    class ExamMonitor
    {
        private Dictionary<string, LinkedList<DateTime>> submissions =
            new Dictionary<string, LinkedList<DateTime>>();

        private Stack<Submission> undoStack = new Stack<Submission>();

        private readonly TimeSpan windowSize = TimeSpan.FromMinutes(1);

        public void SubmitAnswer(string studentId, DateTime timestamp)
        {
            if (!submissions.ContainsKey(studentId))
                submissions[studentId] = new LinkedList<DateTime>();

            var deque = submissions[studentId];

            // Add submission
            deque.AddLast(timestamp);
            undoStack.Push(new Submission { StudentId = studentId, Timestamp = timestamp });

            // Remove expired submissions
            while (deque.Count > 0 && deque.First.Value < timestamp - windowSize)
            {
                deque.RemoveFirst();
            }

            // Detect suspicious activity
            if (deque.Count > 10)
            {
                Console.WriteLine(
                    $"Student {studentId} submitted {deque.Count} answers in 1 minute");
            }
            else
            {
                Console.WriteLine(
                    $"Student {studentId} submission recorded. Count={deque.Count}");
            }
        }

        public void UndoLastSubmission()
        {
            if (undoStack.Count == 0)
            {
                Console.WriteLine("Nothing to undo.");
                return;
            }

            Submission last = undoStack.Pop();

            if (submissions.ContainsKey(last.StudentId))
            {
                submissions[last.StudentId].RemoveLast();
                Console.WriteLine(
                    $"↩ Undo submission for Student {last.StudentId}");
            }
        }
    }

    class OnlineExam    {
        static void Main()
        {
            ExamMonitor monitor = new ExamMonitor();
            DateTime now = DateTime.UtcNow;

            // Dummy data of rapid submissions
            for (int i = 1; i <= 11; i++)
            {
                monitor.SubmitAnswer("S1", now.AddSeconds(i * 5));
            }

            // Undo last submission
            monitor.UndoLastSubmission();

            // Normal student
            monitor.SubmitAnswer("S2", now.AddSeconds(10));
            monitor.SubmitAnswer("S2", now.AddSeconds(40));
        }
    }
}


