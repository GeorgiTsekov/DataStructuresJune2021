using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06SequenceNM
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int startNumber = numbers[0];
            int endNumber = numbers[1];

            if (endNumber < startNumber)
            {
                return;
            }

            Queue<Item> queue = new Queue<Item>();
            queue.Enqueue(new Item(startNumber));

            while (queue.Count > 0)
            {
                Item current = queue.Dequeue();

                if (current.Value == endNumber)
                {
                    PrintSequence(current);
                    return;
                }
                else if (current.Value > endNumber)
                {
                    continue;
                }

                queue.Enqueue(new Item(current.Value + 1, current));
                queue.Enqueue(new Item(current.Value + 2, current));
                queue.Enqueue(new Item(current.Value * 2, current));

            }
        }

        static void PrintSequence(Item start)
        {
            LinkedList<int> list = new LinkedList<int>();

            Item current = start;

            while (current != null)
            {
                list.AddFirst(current.Value);
                current = current.Prev;
            }

            Console.WriteLine(String.Join(" -> ", list));
        }

        class Item
        {
            public int Value { get; set; }

            public Item Prev { get; set; }

            public Item(int value, Item prev = null)
            {
                this.Value = value;
                this.Prev = prev;
            }
        }
    }
}
