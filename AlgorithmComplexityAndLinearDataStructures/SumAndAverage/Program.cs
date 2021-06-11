using System;
using System.Linq;

namespace P01SumAndAverage
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = input.Sum();
            decimal averageNumber = (decimal)input.Average();

            Console.WriteLine($"Sum={sum}; Average={averageNumber:F2}");
        }
    }
}
