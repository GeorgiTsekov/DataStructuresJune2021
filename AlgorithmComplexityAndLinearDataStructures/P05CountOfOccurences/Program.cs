using System;
using System.Collections.Generic;
using System.Linq;

namespace P05CountOfOccurences
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var sortedInput = input.OrderBy(x => x);

            var numbers = new List<int>();

            numbers.AddRange(sortedInput);

            foreach (var number in sortedInput)
            {
                if (numbers.Contains(number))
                {
                    var count = numbers.Where(x => x == number).Count();
                    Console.WriteLine($"{number} -> {count} times");

                    numbers = numbers.Where(x => x != number).ToList();
                }
            }
        }
    }
}
