using System;
using System.Collections.Generic;

namespace FindAllPathsInLabyrinth
{
    class Program
    {
        private static char[,] labyrinth;
        private static List<List<string>> paths;
        private static List<string> directions;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            labyrinth = new char[rows, cols];

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                var arrayOfChars = Console.ReadLine().ToCharArray();
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    labyrinth[row, col] = arrayOfChars[col];
                }
            }
            paths = new List<List<string>>();
            directions = new List<string>();

            FindPaths(0, 0, string.Empty);

            foreach (var p in paths)
            {
                Console.WriteLine(String.Join("", p));
            }
        }

        private static void FindPaths(int row, int col, string direction)
        {
            if (IsOutOfLabyrinth(row, col))
            {
                return;
            }

            if (labyrinth[row, col] == 'v' || labyrinth[row, col] == '*')
            {
                return;
            }

            directions.Add(direction);

            if (labyrinth[row, col] == 'e')
            {
                var path = new List<string>(directions);

                paths.Add(path);
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            labyrinth[row, col] = 'v';

            FindPaths(row + 1, col, "D");
            FindPaths(row - 1, col, "U");
            FindPaths(row, col + 1, "R");
            FindPaths(row, col - 1, "L");

            labyrinth[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

        private static bool IsOutOfLabyrinth(int row, int col)
        {
            if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
