using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRightInMatrixToFindBiggestSum
{
    class Program
    {
        public static int[,] numbers;
        public static int[,] sums;
        private static int rows;
        private static int cols;
        private static Stack<Coordinate> coordinates; 

        static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            numbers = new int[rows, cols];
            sums = new int[rows, cols];
            sums[0, 0] = numbers[0, 0];
            coordinates = new Stack<Coordinate>();

            Input();
            CalculateAndFillSumsWithBiggerNumbers();
            FindBestPath();
            Print();
        }

        private static void Print()
        {
            foreach (var coordinate in coordinates)
            {
                Console.Write($"[{coordinate.X}, {coordinate.Y}] ");
            }
        }

        private static void FindBestPath()
        {
            var currentRow = rows - 1;
            var currentCol = cols - 1;

            var firstCoordinate = new Coordinate(currentRow, currentCol);
            coordinates.Push(firstCoordinate);
            while (currentRow != 0 && currentCol != 0)
            {
                if (sums[currentRow - 1, currentCol] > sums[currentRow, currentCol - 1])
                {
                    var coordinate = new Coordinate(currentRow - 1, currentCol);
                    coordinates.Push(coordinate);
                    currentRow -= 1;
                }
                else
                {
                    var coordinate = new Coordinate(currentRow, currentCol - 1);
                    coordinates.Push(coordinate);
                    currentCol -= 1;
                }
            }

            var lastCoordinate = new Coordinate(0, 0);
            coordinates.Push(lastCoordinate);
        }

        private static void CalculateAndFillSumsWithBiggerNumbers()
        {
            for (int row = 1; row < rows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + numbers[row, 0];
            }

            for (int col = 1; col < cols; col++)
            {
                sums[0, col] = sums[0, col - 1] + numbers[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var result = Math.Max(sums[row - 1, col], sums[row, col - 1]) + numbers[row, col];

                    sums[row, col] = result;
                }
            }
        }

        private static void Input()
        {
            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    numbers[i, j] = line[j];
                }
            }
        }
    }
}
