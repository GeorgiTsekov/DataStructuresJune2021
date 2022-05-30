using System;

namespace ImplementLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddHead(i);
            }
            for (int i = 11; i <= 20; i++)
            {
                linkedList.AddTail(i);
            }

            Console.WriteLine($"removed: {linkedList.RemoveFirst().Value}");
            Console.WriteLine($"removed: {linkedList.RemoveLast().Value}");
            Console.WriteLine($"removed: {linkedList.RemoveFirst().Value}");

            var currentNode = linkedList.Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }

            Console.WriteLine($"first element: {linkedList.Head.Value}");
            Console.WriteLine($"last element: {linkedList.Tail.Value}");
        }
    }
}
