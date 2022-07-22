using System;

namespace EightQueensPuzzle
{
    class Program
    {
        static int size;
        static bool[,] chessboard;

        static void Main()
        {
            size = int.Parse(Console.ReadLine());
            chessboard = new bool[size, size];
            Console.WriteLine(GetEightQueens(0));
        }

        private static int GetEightQueens(int row)
        {
            if (row == size)
            {
                PrintQueens();
                return 1;
            }

            int countOfQueens = 0;

            for (int col = 0; col < size; col++)
            {
                if (IsSave(row, col))
                {
                    chessboard[row, col] = true;
                    countOfQueens += GetEightQueens(row + 1);
                    chessboard[row, col] = false;
                }
            }

            return countOfQueens;
        }

        private static bool IsSave(int row, int col)
        {

            if (IsOutOfChessboard(row, col))
            {
                return false;
            }

            if (chessboard[row, col])
            {
                return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (!IsOutOfChessboard(row - i, col) && chessboard[row - i, col])
                {
                    return false;
                }

                if (!IsOutOfChessboard(row, col - i) && chessboard[row, col - i])
                {
                    return false;
                }

                if (!IsOutOfChessboard(row + i, col) && chessboard[row + i, col])
                {
                    return false;
                }

                if (!IsOutOfChessboard(row, col + i) && chessboard[row, col + i])
                {
                    return false;
                }

                if (!IsOutOfChessboard(row + i, col + i) && chessboard[row + i, col + i])
                {
                    return false;
                }

                if (!IsOutOfChessboard(row + i, col - i) && chessboard[row + i, col - i])
                {
                    return false;
                }

                if (!IsOutOfChessboard(row - i, col + i) && chessboard[row - i, col + i])
                {
                    return false;
                }

                if (!IsOutOfChessboard(row - i, col - i) && chessboard[row - i, col - i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsOutOfChessboard(int row, int col)
        {
            if (row < 0 || col < 0 || row >= size || col >= size)
            {
                return true;
            }

            return false;
        }

        private static void PrintQueens()
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col])
                    {
                        Console.Write("Q" + " ");
                    }
                    if (!chessboard[row, col])
                    {
                        Console.Write("_" + " ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
