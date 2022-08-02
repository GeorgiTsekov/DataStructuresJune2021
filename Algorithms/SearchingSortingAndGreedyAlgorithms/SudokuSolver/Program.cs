using System;

namespace SudokuSolver
{
    class Program
    {
        private static int[,] matrix;

        static void Main()
        {
            matrix = new int[9,9];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[j].ToString());
                }
            }

            SudokuSolver();

            PrintMatrix();
        }

        private static bool SudokuSolver()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        for (int number = 1; number <= 9; number++)
                        {
                            if (IsValid(row, col, number))
                            {
                                matrix[row, col] = number;

                                if (SudokuSolver())
                                {
                                    return true;
                                }
                                else
                                {
                                    matrix[row, col] = 0;
                                }
                            }
                        }
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsValid(int row, int col, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                //check row  
                if (matrix[i, col] != 0 && matrix[i, col] == number)
                {
                    return false;
                }
                //check column  
                if (matrix[row, i] != 0 && matrix[row, i] == number)
                {
                    return false;
                }
                //check 3*3 block  
                int firstCoordinate = 3 * (row / 3) + i / 3;
                int secondCoordinate = 3 * (col / 3) + i % 3;
                if (matrix[firstCoordinate, secondCoordinate] != 0 && matrix[firstCoordinate, secondCoordinate] == number)
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],-2}");
                }
                Console.WriteLine();
            }
        }


    }
}
