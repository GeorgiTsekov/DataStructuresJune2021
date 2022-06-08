using System.Collections.Generic;

namespace MultiplicationTable
{
    public interface IMultiplicationTable
    {
        int Number { get; }

        int[,] MultiplicateFirstNPrimeNumbers();

        bool IsPrime(int currentNumber);

        void AddPrimeNumbersToTheFirstRowColOfTheMatrix(int[,] matrix, List<int> primeNumbers, int number);

        void ForeachOddIntegers(int[,] matrix, List<int> primeNumbers);

        bool IsPrimeNumbersCountIsEqualToNPlusOne(int countOfPrimeNumbers);

        void MultiplicateNumbersInTheMatrix(int[,] matrix);

        int BeautifierBeforePrint(int row, int col, int indent, int[,] matrix);

        string ToString(int[,] matrix);

        void Print(string result);
    }
}
