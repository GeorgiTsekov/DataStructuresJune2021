using System;
using System.Collections.Generic;
using System.Linq;

namespace P04RemoveOddOccurences
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var numbers = new List<int>();

            numbers.AddRange(input);

            foreach (var number in input)
            {
                var oddNumbers = numbers.Where(x => x == number).Count();
                if (oddNumbers % 2 == 1)
                {
                    numbers = numbers.Where(x => x != number).ToList();
                }
            }

            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
