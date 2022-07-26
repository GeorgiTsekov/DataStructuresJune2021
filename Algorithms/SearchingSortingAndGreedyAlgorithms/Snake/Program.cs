using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        private static char[] currentSnake;
        private static HashSet<string> visitedCells;
        private static HashSet<string> results;
        private static HashSet<string> allPossibleSnakes;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            currentSnake = new char[n];
            visitedCells = new HashSet<string>();
            results = new HashSet<string>();
            allPossibleSnakes = new HashSet<string>();

            GenerateSnakes(0, 0, 0, 'S');
            foreach (var snake in results)
            {
                Console.WriteLine(snake);
            }

            Console.WriteLine($"Snakes count = {results.Count}");
        }

        private static void GenerateSnakes(int index, int row, int col, char direction)
        {
            if (index >= currentSnake.Length)
            {
                MarkSnake();
                return;
            }

            var cell = new string($"{row} {col}");

            if (!visitedCells.Contains(cell))
            {
                visitedCells.Add(cell);
                currentSnake[index] = direction;

                GenerateSnakes(index + 1, row, col + 1, 'R');
                GenerateSnakes(index + 1, row + 1, col, 'D');
                GenerateSnakes(index + 1, row, col - 1, 'L');
                GenerateSnakes(index + 1, row - 1, col, 'U');

                visitedCells.Remove(cell);
            }
        }

        private static void MarkSnake()
        {
            var normalSnake = new string(currentSnake);
            if (allPossibleSnakes.Contains(normalSnake))
            {
                return;
            }

            results.Add(normalSnake);

            string flippedSnake = Flip(normalSnake);
            string reversededSnake = Reverse(normalSnake);
            string reversededFlippedSnake = Flip(reversededSnake);

            for (int i = 0; i < 4; i++)
            {
                allPossibleSnakes.Add(normalSnake);
                normalSnake = Rotate(normalSnake);

                allPossibleSnakes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                allPossibleSnakes.Add(reversededSnake);
                reversededSnake = Rotate(reversededSnake);

                allPossibleSnakes.Add(reversededFlippedSnake);
                reversededFlippedSnake = Rotate(reversededFlippedSnake);
            }
        }

        private static string Rotate(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'L'; break;
                    case 'L': newSnake[i] = 'U'; break;
                    case 'U': newSnake[i] = 'R'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        private static string Reverse(string snake)
        {
            var newSnake = new char[snake.Length];
            newSnake[0] = 'S';

            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - i] = snake[i];
            }

            return new string(newSnake);
        }

        private static string Flip(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'U'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }
    }
}
