using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class SinglyLinkedList
{
    private Node head;

    public void Insert(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    public void Delete(int key)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        if (head.Data == key)
        {
            head = head.Next;
            return;
        }

        Node prev = null, curr = head;
        while (curr != null && curr.Data != key)
        {
            prev = curr;
            curr = curr.Next;
        }

        if (curr == null)
            Console.WriteLine("Element not found");
        else
            prev.Next = curr.Next;
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        }
        Console.WriteLine("null");
    }
}

class SLL
{
    static void Main()
    {
        SinglyLinkedList list = new SinglyLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\nSingly Linked List Menu");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Delete");
            Console.WriteLine("3. Display");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter value to insert: ");
                    int val = int.Parse(Console.ReadLine());
                    list.Insert(val);
                    break;

                case 2:
                    Console.Write("Enter value to delete: ");
                    int key = int.Parse(Console.ReadLine());
                    list.Delete(key);
                    break;

                case 3:
                    list.Display();
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 4);
    }
}
