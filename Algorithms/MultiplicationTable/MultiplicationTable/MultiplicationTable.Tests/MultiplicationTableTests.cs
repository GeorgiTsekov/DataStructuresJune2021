using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MultiplicationTable.Tests
{
    [TestFixture]
    public class MultiplicationTableTests
    {
        private int[,] matrixForTests;
        private List<int> primeNumbersForTest;
        private MultiplicationTable table;
        private int[,] matrixWithFirstPrimeNumber;
        private int number;

       [SetUp]
        public void Setup()
        {
            number = 5;
            table = new MultiplicationTable(number);
            matrixWithFirstPrimeNumber = new int[number + 1, number + 1];
            matrixWithFirstPrimeNumber[1, 0] = Constants.SECOND_NUMBER;
            matrixWithFirstPrimeNumber[0, 1] = Constants.SECOND_NUMBER;

            matrixForTests = new int[number + 1, number + 1];
            matrixForTests[1, 0] = 2;
            matrixForTests[0, 1] = 2;
            matrixForTests[2, 0] = 3;
            matrixForTests[0, 2] = 3;
            matrixForTests[3, 0] = 5;
            matrixForTests[0, 3] = 5;
            matrixForTests[4, 0] = 7;
            matrixForTests[0, 4] = 7;
            matrixForTests[5, 0] = 11;
            matrixForTests[0, 5] = 11;

            primeNumbersForTest = new List<int>
            {
                Constants.FIRST_NUMBER,
                Constants.SECOND_NUMBER
            };
        }

        [TestCase(15)]
        [TestCase(2)]
        [TestCase(600)]
        public void IsConstructorReturnSameValueAsN(int n)
        {
            var currentTable = new MultiplicationTable(n);
            Assert.AreEqual(n, currentTable.Number);
        }

        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(1)]
        public void IsConstructoThrowExceptionWhenNIsSmallerThen2OrBiggerThen7000(int n)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultiplicationTable(n));
        }

        [TestCase]
        public void IsToStringReturnsSameStringAsWithTheOtherMatrix()
        {
            var currentMatrix = table.MultiplicateFirstNPrimeNumbers();
            var result = table.ToString(currentMatrix);

            var newTable = new MultiplicationTable(number);
            newTable.ForeachOddIntegers(matrixForTests, primeNumbersForTest);
            newTable.MultiplicateNumbersInTheMatrix(matrixForTests);
            newTable.MultiplicateFirstNPrimeNumbers();
            var otherTableResult = newTable.ToString(matrixForTests);

            Assert.AreEqual(result, otherTableResult);
        }

        [TestCase]
        public void IsToStringReturnsCorrectStringLength()
        {
            var newTable = new MultiplicationTable(number);
            newTable.ForeachOddIntegers(matrixForTests, primeNumbersForTest);
            newTable.MultiplicateNumbersInTheMatrix(matrixForTests);
            newTable.MultiplicateFirstNPrimeNumbers();
            var otherTableResult = newTable.ToString(matrixForTests);

            Assert.AreEqual(316, otherTableResult.Length);
        }


        [TestCase(997)]
        [TestCase(2)]
        [TestCase(71)]
        public void IsPrimeReturnTrueIfNIsPrime(int n)
        {
            bool result = table.IsPrime(n);
            Assert.AreEqual(result, true);
        }

        [TestCase(1025)]
        [TestCase(4)]
        [TestCase(70)]
        public void IsPrimeReturnFalseIfNIsNotPrime(int n)
        {
            bool result = table.IsPrime(n);
            Assert.AreEqual(result, false);
        }

        [TestCase(5)]
        [TestCase(71)]
        [TestCase(11)]
        public void IsAddPrimeNumbersToTheFirstRowColOfTheMatrixWorksCorrectly(int number)
        {
            table.AddPrimeNumbersToTheFirstRowColOfTheMatrix(matrixWithFirstPrimeNumber, primeNumbersForTest, number);

            Assert.AreEqual(matrixWithFirstPrimeNumber[0, primeNumbersForTest.Count - 1], number);
            Assert.AreEqual(matrixWithFirstPrimeNumber[primeNumbersForTest.Count - 1, 0], number);
        }

        [TestCase(6)]
        [TestCase(2)]
        [TestCase(5)]
        public void IsBeautifierBeforePrintReturnIndent(int number)
        {
            int row = 1;
            int col = 0;
            matrixForTests[row, col] = number;
            var table = new MultiplicationTable(5);
            var result = table.BeautifierBeforePrint(row, col, Constants.INDENT, matrixForTests);

            Assert.AreEqual(result, Constants.INDENT);
        }

        [TestCase(711)]
        [TestCase(143)]
        [TestCase(511)]
        public void IsBeautifierBeforePrintReturnIndentMinusOne(int number)
        {
            int row = 1;
            int col = 0;
            matrixForTests[row, col] = number;
            var table = new MultiplicationTable(5);
            var result = table.BeautifierBeforePrint(row, col, Constants.INDENT, matrixForTests);

            Assert.AreEqual(result, Constants.INDENT - 2);
        }

        [TestCase]
        public void IsMultiplicateNumbersInTheMatrixShouldReturnTheSameMultipliedMatrix()
        {
            table.ForeachOddIntegers(matrixWithFirstPrimeNumber, primeNumbersForTest);
            table.MultiplicateNumbersInTheMatrix(matrixWithFirstPrimeNumber);
            
            table.MultiplicateNumbersInTheMatrix(matrixForTests);

            Assert.AreEqual(matrixWithFirstPrimeNumber, matrixForTests);
        }

        [TestCase]
        public void IsMultiplicateNumbersInTheMatrixShouldReturnTheSameMultipliedMatrixResultByIndexes()
        {
            var table = new MultiplicationTable(5);
            table.MultiplicateNumbersInTheMatrix(matrixForTests);

            Assert.AreEqual(matrixForTests[5,3], 55);
        }

        [TestCase]
        public void IsForeachOddIntegersShouldReturnSameMatrix()
        {
            table.ForeachOddIntegers(matrixWithFirstPrimeNumber, primeNumbersForTest);

            Assert.AreEqual(matrixWithFirstPrimeNumber, matrixForTests);
        }

        [TestCase]
        public void IIsPrimeNumbersCountIsEqualToNPlusOneReturnTrue()
        {
            table.ForeachOddIntegers(matrixWithFirstPrimeNumber, primeNumbersForTest);

            Assert.AreEqual(table.IsPrimeNumbersCountIsEqualToNPlusOne(primeNumbersForTest.Count), true);
        }

        [TestCase]
        public void IIsPrimeNumbersCountIsEqualToNPlusOneReturnFalse()
        {
            table.ForeachOddIntegers(matrixWithFirstPrimeNumber, primeNumbersForTest);

            Assert.AreEqual(table.IsPrimeNumbersCountIsEqualToNPlusOne(primeNumbersForTest.Count - 1), false);
        }
    }
}
