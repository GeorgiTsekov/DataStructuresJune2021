using System;
using System.Collections.Generic;

namespace CombinationsWithRepetitions
{
    class Program
    {
        private static char[] elements;
        private static int n;
        private static bool[] used;

        static void Main()
        {
            var input = Console.ReadLine();
            n = int.Parse(Console.ReadLine());
            elements = input.ToCharArray();
            used = new bool[elements.Length];

            var word = new List<char>();

            GenCombinaion(0, word);
        }

        private static void GenCombinaion(int index, List<char> word)
        {
            if (index >= n)
            {
                Console.WriteLine(string.Join(" ", word));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        word.Add(elements[i]);
                        GenCombinaion(index + 1, word);
                        word.RemoveAt(word.Count - 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
