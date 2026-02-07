//Action1 → Action2 → Action3 → Action4 → Action5
//Due to a bug, the last K actions must be removed.

//Task:

//Delete the last K nodes from the linked list
//Single traversal only

//Constraints:

//-No length calculation
//-No extra data structures
//- Only one pass


using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int value)
    {
        Data = value;
        Next = null;
    }
}

class LinkedList
{
    private Node head;
    public void Insert(int value)
    {
        Node newNode = new Node(value);
                if (head == null)
        {
            head = newNode;
            return;
        }
                Node curr = head;
        while (curr.Next != null)
        {
            curr = curr.Next;
        }
        curr.Next = newNode;
    }
    public void RemoveLastKNodes(int k)
    {
        if (head == null || k <= 0)
            return;
        Node fast = head;
        Node slow = head;
        for (int i = 0; i < k; i++)
        {
            if (fast == null)
            {
                head = null;
                return;
            }
            fast = fast.Next;
        }
        if (fast == null)
        {
            head = null;
            return;
        }
        while (fast.Next != null)
        {
            fast = fast.Next;
            slow = slow.Next;
        }
        slow.Next = null;
    }

    public void Display()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        list.Insert(1);
        list.Insert(2);
        list.Insert(3);
        list.Insert(4);
        list.Insert(5);

        Console.WriteLine("Input:");
        list.Display();

        list.RemoveLastKNodes(2);

        Console.WriteLine("Output:");
        list.Display();
    }
}


