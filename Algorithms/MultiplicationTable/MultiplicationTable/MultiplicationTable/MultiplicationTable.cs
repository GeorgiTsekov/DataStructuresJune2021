using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MultiplicationTable
{
    public class MultiplicationTable : IMultiplicationTable
    {
        private int number;

        public MultiplicationTable(int number)
        {
            this.Number = number;
        }

        public int Number
        {
            get
            {
                return number;
            }
            private set
            {
                if (value < 2 || value > 7000)
                {
                    throw new ArgumentOutOfRangeException($"Integer: {value} is not valid. Integer shout be bigger then 1!");
                }

                number = value;
            }
        }

        public int[,] MultiplicateFirstNPrimeNumbers()
        {
            List<int> primeNumbers = CreateListOfPrimeNumbersAndAddFirstAndSecondNumbers();
            int[,] matrix = CreateMatrixAndAddFirstPrimeNumber();

            ForeachOddIntegers(matrix, primeNumbers);
            MultiplicateNumbersInTheMatrix(matrix);
            return matrix;
        }

        public void Print(string result)
        {
            using (StreamWriter stream = new StreamWriter("myTextFile.txt", false, Encoding.UTF8))
            {
                stream.Write(result);
            }

            Console.WriteLine(result);
        }

        public string ToString(int[,] matrix)
        {
            var result = new StringBuilder();
            result.Append(Environment.NewLine + Environment.NewLine);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == 0 && col == 0)
                    {
                        result.Append(new string(' ', Constants.INDENT + 1));
                        continue;
                    }

                    var indent = BeautifierBeforePrint(row, col, Constants.INDENT, matrix);

                    result
                        .Append(matrix[row, col])
                        .Append(new string(' ', indent));
                }
                result.Append(Environment.NewLine + Environment.NewLine);
            }

            return result.ToString();
        }

        public bool IsPrime(int currentNumber)
        {
            for (int i = 2; i < currentNumber; i++)
            {
                if (currentNumber % i == 0)
                {
                    return false;
                }

                if (i > 2)
                {
                    i++;
                }
            }

            return true;
        }

        public void AddPrimeNumbersToTheFirstRowColOfTheMatrix(int[,] matrix, List<int> primeNumbers, int number)
        {
            matrix[0, primeNumbers.Count - 1] = number;
            matrix[primeNumbers.Count - 1, 0] = number;
        }

        public void ForeachOddIntegers(int[,] matrix, List<int> primeNumbers)
        {
            for (int i = 3; i < int.MaxValue; i += 2)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                    AddPrimeNumbersToTheFirstRowColOfTheMatrix(matrix, primeNumbers, i);
                }

                if (IsPrimeNumbersCountIsEqualToNPlusOne(primeNumbers.Count))
                {
                    break;
                }
            }
        }

        public bool IsPrimeNumbersCountIsEqualToNPlusOne(int countOfPrimeNumbers)
        {
            if (countOfPrimeNumbers == this.Number + 1)
            {
                return true;
            }

            return false;
        }

        public void MultiplicateNumbersInTheMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row > 0 && col > 0)
                    {
                        matrix[row, col] = matrix[0, col] * matrix[row, 0];
                    }
                }
            }
        }

        public int BeautifierBeforePrint(int row, int col, int indent, int[,] matrix)
        {
            if (matrix[row, col] > 9999999)
            {
                indent = Constants.INDENT - 7;
            }
            else if (matrix[row, col] > 999999)
            {
                indent = Constants.INDENT - 6;
            }
            else if (matrix[row, col] > 99999)
            {
                indent = Constants.INDENT - 5;
            }
            else if (matrix[row, col] > 9999)
            {
                indent = Constants.INDENT - 4;
            }
            else if (matrix[row, col] > 999)
            {
                indent = Constants.INDENT - 3;
            }
            else if (matrix[row, col] > 99)
            {
                indent = Constants.INDENT - 2;
            }
            else if (matrix[row, col] > 9)
            {
                indent = Constants.INDENT - 1;
            }

            return indent;
        }

        private static List<int> CreateListOfPrimeNumbersAndAddFirstAndSecondNumbers()
        {
            return new List<int>
            {
                Constants.FIRST_NUMBER,
                Constants.SECOND_NUMBER
            };
        }

        private int[,] CreateMatrixAndAddFirstPrimeNumber()
        {
            int[,] matrix = new int[number + 1, number + 1];
            matrix[1, 0] = Constants.SECOND_NUMBER;
            matrix[0, 1] = Constants.SECOND_NUMBER;
            return matrix;
        }
    }
}
