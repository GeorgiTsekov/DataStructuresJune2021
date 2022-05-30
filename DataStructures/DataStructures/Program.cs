using ImplementList;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main()
        {
            var list = new MyList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(list[5]);
            Console.WriteLine(list[7]);
            Console.WriteLine(list.Contains(5));

            Console.WriteLine(list.RemoveAt(5));
            Console.WriteLine(list.Remove(7));
            Console.WriteLine(list.Contains(7));

            Console.WriteLine(list[5]);
            Console.WriteLine(list[7]);
            Console.WriteLine(list.InternalArrayCount);
            Console.WriteLine(list.Count);

            list.Add(11);
            list.Add(12);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine(list.InternalArrayCount);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Contains(5));
        }
    }
}
