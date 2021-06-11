using System;
using System.Collections.Generic;
using System.Linq;

namespace P03LonguestSubsequence
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var longuestSequence = new List<int>();
            var normalSequence = new List<int>();
            foreach (var number in input)
            {
                if (normalSequence.Count == 0)
                {
                    normalSequence.Add(number);
                }
                else if (normalSequence.Contains(number))
                {
                    normalSequence.Add(number);
                }
                else
                {
                    if (normalSequence.Count > longuestSequence.Count)
                    {
                        longuestSequence.Clear();
                        longuestSequence.AddRange(normalSequence);
                        normalSequence.Clear();
                        normalSequence.Add(number);
                    }
                    else
                    {
                        normalSequence.Clear();
                        normalSequence.Add(number);
                    }
                }
            }

            if (longuestSequence.Count < normalSequence.Count)
            {
                longuestSequence.Clear();
                longuestSequence.AddRange(normalSequence);
            }

            foreach (var number in longuestSequence)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
