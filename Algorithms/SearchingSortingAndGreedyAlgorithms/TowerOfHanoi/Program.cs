using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    class Program
    {
        private static int steps;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var source = new Stack<int>(Enumerable.Range(1, n).Reverse());
            var destination = new Stack<int>();
            var spare = new Stack<int>();
            steps = 0;

            MoveDisks(n, source, spare, destination);
        }

        private static void MoveDisks(int discs, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (discs == 0)
            {
                Console.WriteLine($"step: {steps++}");
                Console.WriteLine($"source: {string.Join(" ", source)}");
                Console.WriteLine($"spare: {string.Join(" ", spare)}");
                Console.WriteLine($"destination: {string.Join(" ", destination)}");
                return;
            }

            MoveDisks(discs - 1, source, spare, destination);

            destination.Push(source.Pop());

            MoveDisks(discs - 1, spare, destination, source);
        }
    }
}
