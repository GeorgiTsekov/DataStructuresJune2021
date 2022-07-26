using System;
using System.Collections.Generic;
using System.Linq;

namespace EgyptianFractions
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var splitedInput = input.Split("/").Select(int.Parse).ToArray();
            decimal numerator = splitedInput[0];
            decimal denumerator = splitedInput[1];
            var fractions = new List<int>();

            if (numerator / denumerator >= 1)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            for (int i = 2; i < int.MaxValue; i++)
            {
                if (numerator == 0)
                {
                    break;
                }

                var nextNumerator = i * numerator;
                var remaining = nextNumerator - denumerator;

                if (remaining < 0)
                {
                    continue;
                }

                fractions.Add(i);

                numerator = remaining;
                denumerator = i * denumerator;
            }

            Console.WriteLine($"{input} = 1/{string.Join(" + 1/", fractions)}");
        }
    }
}
