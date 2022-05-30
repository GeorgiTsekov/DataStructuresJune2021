using System;

namespace ImplementQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> stack = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Enqueue(i);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Peek());
                Console.WriteLine(stack.Dequeue());
            }
        }
    }
}
