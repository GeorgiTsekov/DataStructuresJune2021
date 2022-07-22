using System;
using System.Linq;

namespace ArrayOfSum
{
    class Program
    {
        static void Main()
        {
            var arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Sum(arrayOfNumbers, 0));
        }

        private static int Sum(int[] arrayOfNumbers, int index)
        {
            if (index == arrayOfNumbers.Length - 1)
            {
                return arrayOfNumbers[index];
            }

            return arrayOfNumbers[index] + Sum(arrayOfNumbers, index + 1);
        }
    }
}
