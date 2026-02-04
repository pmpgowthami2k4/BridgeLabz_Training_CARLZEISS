using System;

class QueueUsingLinkedList
{
    // Node definition
    class Node
    {
        public int data;
        public Node next;

        public Node(int value)
        {
            data = value;
            next = null;
        }
    }

    private Node front;
    private Node rear;

    public QueueUsingLinkedList()
    {
        front = null;
        rear = null;
    }

    // Enqueue operation
    public void Enqueue(int value)
    {
        Node newNode = new Node(value);

        if (rear == null)
        {
            front = rear = newNode;
            Console.WriteLine("Inserted: " + value);
            return;
        }

        rear.next = newNode;
        rear = newNode;
        Console.WriteLine("Inserted: " + value);
    }

    // Dequeue operation
    public void Dequeue()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is Empty. Cannot dequeue.");
            return;
        }

        Console.WriteLine("Removed: " + front.data);
        front = front.next;

        if (front == null)
            rear = null;
    }

    // Peek operation
    public void Peek()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is Empty.");
            return;
        }

        Console.WriteLine("Front element: " + front.data);
    }

    // Check if queue is empty
    public void IsEmpty()
    {
        if (front == null)
            Console.WriteLine("Queue is Empty.");
        else
            Console.WriteLine("Queue is NOT Empty.");
    }

    // Display queue elements
    public void Display()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is Empty.");
            return;
        }

        Console.Write("Queue elements: ");
        Node temp = front;
        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }
}

class QueueLL
{
    static void Main()
    {
        QueueUsingLinkedList queue = new QueueUsingLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- QUEUE USING LINKED LIST ---");
            Console.WriteLine("1. Enqueue");
            Console.WriteLine("2. Dequeue");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Is Empty");
            Console.WriteLine("5. Display");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter value to insert: ");
                    int value = int.Parse(Console.ReadLine());
                    queue.Enqueue(value);
                    break;

                case 2:
                    queue.Dequeue();
                    break;

                case 3:
                    queue.Peek();
                    break;

                case 4:
                    queue.IsEmpty();
                    break;

                case 5:
                    queue.Display();
                    break;

                case 6:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 6);
    }
}

