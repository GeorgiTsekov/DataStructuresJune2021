using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    class Program
    {
        static void Main()
        {
            var queue = new PriorityQueue<int>();
            var elements = new List<int>() { 4, 3, 0, 15, 6, 9, 5, 25, 8, 17, 16, 12, 2, 7, 8, 1, 10, 11, 51, 50, 45, 13, 14, 88, 15, 77, 16, 99, 18, 87, 19, 81, 20 };
            foreach (var element in elements)
            {
                queue.Enqueue(element);
            }

            while (queue.Size > 0)
            {
                Console.WriteLine();

                Console.WriteLine($"Max element: {queue.Peek()}");

                Console.WriteLine(queue.DFSInOrder(0, 0));

                Console.WriteLine($"Max element: {queue.Dequeue()}");
            }
        }
    }
}
