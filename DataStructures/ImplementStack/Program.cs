using System;

namespace ImplementStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Peek());
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
