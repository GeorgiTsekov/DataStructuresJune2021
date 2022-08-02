using System;

namespace Fibonachi
{
    class Program
    {
        private static long[] numbers;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            numbers = new long[n + 1];
            Console.WriteLine(Fibonachi(n));
        }

        private static long Fibonachi(int n)
        {
            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            var result =  Fibonachi(n - 1) + Fibonachi(n - 2);

            numbers[n] = result;

            return result;
        }
    }
}
