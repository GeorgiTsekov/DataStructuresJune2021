using System;
using System.Collections.Generic;
using System.Linq;

namespace P01WithStack
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new Stack<int>();

            foreach (var number in input)
            {
                stack.Push(number);
            }

            for (int i = 0; i < input.Count; i++)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
