using System;
using System.Collections.Generic;

namespace NestedLoopsRecursion
{
    class Program
    {
        private static int n;
        static void Main()
        {
            n = int.Parse(Console.ReadLine());

            NestedLoops(new Stack<int>(), 0, n);
        }

        private static void NestedLoops(Stack<int> stack, int currentInteration, int n)
        {
            if (currentInteration == n)
            {
                Console.WriteLine(String.Join(" ", stack));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                stack.Push(i);
                NestedLoops(stack, currentInteration + 1, n);
                stack.Pop();
            }
        }
    }
}
