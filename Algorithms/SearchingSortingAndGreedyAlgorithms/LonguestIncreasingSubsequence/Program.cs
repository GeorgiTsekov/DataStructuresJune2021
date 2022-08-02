using System;
using System.Collections.Generic;
using System.Linq;

namespace LonguestIncreasingSubsequence
{
    class Program
    {
        private static Dictionary<int, List<int>> sequences;
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            sequences = new Dictionary<int, List<int>>();

            var longuestSequence = LonguestIncreasingSubsequence(numbers);
            Console.WriteLine(string.Join(" ", longuestSequence));
        }

        private static List<int> LonguestIncreasingSubsequence(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                foreach (var sequence in sequences.Values)
                {
                    if (sequence.Last() <= number)
                    {
                        sequence.Add(number);
                    }
                }

                sequences.Add(i, new List<int>());
                sequences[i].Add(number);
            }

            var longuestSequence = sequences.Values.OrderByDescending(x => x.Count).FirstOrDefault();
            return longuestSequence;
        }
    }
}
