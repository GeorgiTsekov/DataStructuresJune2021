using System;
using System.Collections.Generic;

namespace Heap
{
    public class Program
    {
        static void Main()
        {
            var integerHeap = new Heap<int>();
            var elements = new List<int>() { 4, 3, 0, 1, 15, 6, 9, 5, 25, 8, 17, 16, 12, 2, 7, 8, 1, 10, 11, 51, 50, 45, 13, 14, 88, 15, 77, 16, 99, 18, 87, 19, 81, 20 };
            foreach (var element in elements)
            {
                integerHeap.Add(element);
            }

            Console.WriteLine(integerHeap.DFSInOrder(0, 0));
        }
    }
}
