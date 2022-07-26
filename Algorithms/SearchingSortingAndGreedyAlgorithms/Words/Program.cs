using System;
using System.Collections.Generic;

namespace Words
{
    class Program
    {
        private static char[] elements;
        private static int count;

        static void Main()
        {
            var input = Console.ReadLine();

            elements = input.ToCharArray();

            GenWord(0);

            Console.WriteLine(count);
        }

        private static void GenWord(int index)
        {
            if (index >= elements.Length)
            {
                for (int i = 1; i < elements.Length; i++)
                {
                    if (elements[i] == elements[i - 1])
                    {
                        return;
                    }
                }

                count++;
            }
            else
            {
                var swapped = new HashSet<char>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        GenWord(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        } 

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
