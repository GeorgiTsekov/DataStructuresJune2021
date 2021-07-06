using System;

namespace P00RecursionDemo
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Print(n);
        }

        private static void Print(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine($"Print me {n} times!" + n);
            Print(n - 1);
        }
    }
}
