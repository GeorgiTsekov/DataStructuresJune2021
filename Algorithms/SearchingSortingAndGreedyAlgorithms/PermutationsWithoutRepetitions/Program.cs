using System;
using System.Collections.Generic;

namespace PermutationsWithoutRepetitions
{
    class Program
    {
        private static char[] elements;

        static void Main()
        {
            var input = Console.ReadLine();

            elements = input.ToCharArray();

            GenPermutation(0);
        }

        private static void GenPermutation(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                var swapped = new HashSet<char>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        GenPermutation(index + 1);
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
