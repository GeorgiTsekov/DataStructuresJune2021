using System;

namespace RecursiveFacturiel
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Facturiel(number));
        }

        private static long Facturiel(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            Console.WriteLine(number);
            return number * Facturiel(number - 1);
        }
    }
}
