using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplicationTable
{
    public class MultiplicationTable : IMultiplicationTable
    {
        private List<int> primeNumbers;
        private int[,] matrix;
        private int number;

        public MultiplicationTable(int number)
        {
            this.Number = number;
            this.primeNumbers = new List<int>
            {
                Constants.FIRST_NUMBER,
                Constants.SECOND_NUMBER
            };
            this.matrix = new int[number + 1, number + 1];
            this.matrix[1, 0] = Constants.SECOND_NUMBER;
            this.matrix[0, 1] = Constants.SECOND_NUMBER;
        }
        public int Number
        {
            get 
            { 
                return number; 
            }
            set
            {
                if (value < 2 || value > 7000)
                {
                    throw new ArgumentOutOfRangeException($"Integer: {value} is not valid. Integer shout be bigger then 1!");
                }

                number = value; 
            }
        }

        public string MultiplicateFirstNPrimeNumbers()
        {
            ForeachOddIntegers();
            return MultiplicateNumbersInTheMatrix();
        }

        public void Print(string result)
        {
            Console.WriteLine(result);
        }

        private static bool IsPrime(int currentNumber)
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

        private void AddPrimeNumbersToTheFirstRowColOfTheMatrix(int number)
        {
            this.matrix[0, primeNumbers.Count - 1] = number;
            this.matrix[primeNumbers.Count - 1, 0] = number;
        }

        private void ForeachOddIntegers()
        {
            for (int i = 3; i < int.MaxValue; i += 2)
            {
                if (IsPrime(i))
                {
                    this.primeNumbers.Add(i);
                    AddPrimeNumbersToTheFirstRowColOfTheMatrix(i);
                }

                if (!IsPrimeNumbersCountIsEqualToN())
                {
                    break;
                }
            }
        }

        private bool IsPrimeNumbersCountIsEqualToN()
        {
            if (this.primeNumbers.Count == this.Number + 1)
            {
                return false;
            }

            return true;
        }

        private string MultiplicateNumbersInTheMatrix()
        {
            var result = new StringBuilder();
            result.Append(Environment.NewLine + Environment.NewLine);
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (row == 0 && col == 0)
                    {
                        result.Append(new string(' ', Constants.INDENT + 1));
                        continue;
                    }

                    if (row > 0 && col > 0)
                    {
                        this.matrix[row, col] = this.matrix[0, col] * this.matrix[row, 0];
                    }

                    var indent = BeautyfierBeforePrint(row, col, Constants.INDENT);

                    result
                        .Append(this.matrix[row, col])
                        .Append(new string(' ', indent));
                }
                result.Append(Environment.NewLine + Environment.NewLine + Environment.NewLine);
            }

            return result.ToString();
        }

        private int BeautyfierBeforePrint(int row, int col, int indent)
        {
            if (this.matrix[row, col] > 999999)
            {
                indent = Constants.INDENT - 6;
            }
            else if (this.matrix[row, col] > 99999)
            {
                indent = Constants.INDENT - 5;
            }
            else if (this.matrix[row, col] > 9999)
            {
                indent = Constants.INDENT - 4;
            }
            else if (this.matrix[row, col] > 999)
            {
                indent = Constants.INDENT - 3;
            }
            else if (this.matrix[row, col] > 99)
            {
                indent = Constants.INDENT - 2;
            }
            else if (this.matrix[row, col] > 9)
            {
                indent = Constants.INDENT - 1;
            }

            return indent;
        }

  }
}
