using System;

namespace KnightsTour
{
    class Program
    {
        private static int[,] matrix;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new int[n, n];

            KnightMove(1, 0, 0);
            PrintMatrix();
        }

        private static void KnightMove(int number, int row, int col)
        {
            if (!IsAnyNotFilledFieldInTheMatrix())
            {
                return;
            }

            if (CoordinatesAreOutside(row, col))
            {
                return;
            }

            if (CoordinatesAreVisited(row, col))
            {
                return;
            }

            matrix[row, col] = number;

            KnightMove(number + 1, row - 2, col - 1);
            KnightMove(number + 1, row - 1, col - 2);
            KnightMove(number + 1, row + 1, col - 2);
            KnightMove(number + 1, row + 2, col - 1);
            KnightMove(number + 1, row + 2, col + 1);
            KnightMove(number + 1, row + 1, col + 2);
            KnightMove(number + 1, row - 2, col + 1);
            KnightMove(number + 1, row - 1, col + 2);

            return;
        }

        private static bool IsAnyNotFilledFieldInTheMatrix()
        {
            bool isZero = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (isZero)
                {
                    break;
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        isZero = true;
                        break;
                    }
                }
            }

            return isZero;
        }

        private static bool CoordinatesAreVisited(int row, int col)
        {
            if (matrix[row, col] != 0)
            {
                return true;
            }

            return false;
        }

        private static bool CoordinatesAreOutside(int row, int col)
        {
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || row < 0 || col < 0)
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],-10}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
