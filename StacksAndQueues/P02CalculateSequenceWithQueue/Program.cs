using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(number);
            Queue<int> newStack = new Queue<int>();
            newStack.Enqueue(number);
            for (int i = 0; i < 50; i++)
            {
                int newNumber = newStack.Dequeue();

                newStack.Enqueue(newNumber + 1);
                newStack.Enqueue(newNumber * 2 + 1);
                newStack.Enqueue(newNumber + 2);
                queue.Enqueue(newNumber + 1);
                queue.Enqueue(newNumber * 2 + 1);
                queue.Enqueue(newNumber + 2);
            }

            for (int i = 0; i < 50; i++)
            {
                if (i == 49)
                {
                    Console.WriteLine(queue.Dequeue());
                }
                else
                {
                    Console.Write(queue.Dequeue() + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}
