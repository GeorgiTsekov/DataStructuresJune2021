using System;

namespace P02NFactoriel
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(NFactoriel(n));
        }

        private static int NFactoriel(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            int current =  n * NFactoriel(n - 1);

            return current;
        }
    }
}
