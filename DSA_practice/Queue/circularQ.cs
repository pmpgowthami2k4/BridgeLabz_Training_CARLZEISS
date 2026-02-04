public class QueueUsingArray
{
    private int[] arr;
    private int front;
    private int rear;
    private int size;
    private int capacity;

    public QueueUsingArray(int capacity)
    {
        this.capacity = capacity;
        arr = new int[capacity];
        front = 0;
        rear = -1;
        size = 0;
    }

    public void Enqueue(int value)
    {
        if (size == capacity)
        {
            Console.WriteLine("Queue Overflow");
            return;
        }

        rear = (rear + 1) % capacity;
        arr[rear] = value;
        size++;
    }

    public void Dequeue()
    {
        if (size == 0)
        {
            Console.WriteLine("Queue Underflow");
            return;
        }

        front = (front + 1) % capacity;
        size--;
    }

    public int Peek()
    {
        if (size == 0)
        {
            Console.WriteLine("Queue is Empty");
            return -1;
        }

        return arr[front];
    }

    public bool IsEmpty()
    {
        return size == 0;
    }
}
