using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        // TODO
        throw new NotImplementedException();
    }

    public void Enqueue(T element)
    {
        // TODO
        throw new NotImplementedException();
    }

    private void Resize()
    {
        // TODO
        throw new NotImplementedException();
    }

    private void CopyAllElements(T[] newArray)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        // TODO
        throw new NotImplementedException();
    }

    public T[] ToArray()
    {
        // TODO
        throw new NotImplementedException();
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
