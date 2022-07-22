using System;
using System.Linq;

namespace GeneratingCombinations
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];

            GenCombs(numbers, vector, 0, 0);
        }

        private static void GenCombs(int[] numbers, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < numbers.Length; i++)
            {
                vector[index] = numbers[i];
                GenCombs(numbers, vector, index + 1, i + 1);
            }
        }
    }
}
