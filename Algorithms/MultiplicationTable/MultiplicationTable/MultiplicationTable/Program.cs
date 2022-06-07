using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplicationTable
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Add integer: ");
            int n = int.Parse(Console.ReadLine());
            var result = MultiplicateFirstNPrimeNumbers(n);
            Print(result);
        }

        private static string MultiplicateFirstNPrimeNumbers(int n)
        {
            var primeNumbers = new List<int>()
            {
                Constants.FIRST_NUMBER,
                Constants.SECOND_NUMBER
            };

            var matrix = new int[n + 1, n + 1];
            matrix[1, 0] = Constants.SECOND_NUMBER;
            matrix[0, 1] = Constants.SECOND_NUMBER;
            ForeachEvenIntegers(n, primeNumbers, matrix);
            var result = MultiplicateNumbersInTheMatrix(matrix);
            return result;
        }

        private static void Print(string result)
        {
            Console.WriteLine(result);
        }

        private static string MultiplicateNumbersInTheMatrix(int[,] matrix)
        {
            var result = new StringBuilder();
            result.Append(Environment.NewLine);
            result.Append(Environment.NewLine);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == 0 && col == 0)
                    {
                        result.Append(new string(' ', Constants.INDENT + 1));
                        continue;
                    }

                    if (row > 0 && col > 0)
                    {
                        matrix[row, col] = matrix[0, col] * matrix[row, 0];
                    }

                    int indent = Constants.INDENT;
                    indent = BeautyfierBeforePrint(matrix, row, col, indent);

                    result
                        .Append(matrix[row, col])
                        .Append(new string(' ', indent));
                }
                result.Append(Environment.NewLine);
                result.Append(Environment.NewLine);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        private static int BeautyfierBeforePrint(int[,] matrix, int row, int col, int indent)
        {
            if (matrix[row, col] > 9 && matrix[row, col] < 100)
            {
                indent = Constants.INDENT - 1;
            }
            else if (matrix[row, col] > 99 && matrix[row, col] < 1000)
            {
                indent = Constants.INDENT - 2;
            }
            else if (matrix[row, col] > 999 && matrix[row, col] < 10000)
            {
                indent = Constants.INDENT - 3;
            }
            else if (matrix[row, col] > 9999 && matrix[row, col] < 100000)
            {
                indent = Constants.INDENT - 4;
            }
            else if (matrix[row, col] > 99999 && matrix[row, col] < 1000000)
            {
                indent = Constants.INDENT - 5;
            }

            return indent;
        }

        private static void ForeachEvenIntegers(int n, List<int> primeNumbers, int[,] matrix)
        {
            for (int i = 3; i < int.MaxValue; i += 2)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                    AddPrimeNumbersToTheFirstRowColOfTheMatrix(primeNumbers, matrix, i);
                }

                if (!IsPrimenumbersCountIsEqualToN(n, primeNumbers))
                {
                    break;
                }
            }
        }
        private static bool IsPrimenumbersCountIsEqualToN(int n, List<int> primeNumbers)
        {
            if (primeNumbers.Count == n + 1)
            {
                return false;
            }

            return true;
        }

        private static void AddPrimeNumbersToTheFirstRowColOfTheMatrix(List<int> primeNumbers, int[,] matrix, int i)
        {
            matrix[0, primeNumbers.Count - 1] = i;
            matrix[primeNumbers.Count - 1, 0] = i;
        }

        private static bool IsPrime(int i)
        {
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    return false;
                }

                if (j > 2)
                {
                    j++;
                }
            }

            return true;
        }
    }
}
