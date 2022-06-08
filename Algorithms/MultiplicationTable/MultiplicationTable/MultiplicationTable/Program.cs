using System;
using System.IO;

namespace MultiplicationTable
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Add integer between 2 and 7000: ");
            string input = Console.ReadLine();
            var integerValidation = new IntegerValidation();
            var n = integerValidation.IsValid(input);

            var multiplicationTable = new MultiplicationTable(n);
            var matrix = multiplicationTable.MultiplicateFirstNPrimeNumbers();
            var result = multiplicationTable.ToString(matrix);
            multiplicationTable.Print(result);
        }
    }
}
