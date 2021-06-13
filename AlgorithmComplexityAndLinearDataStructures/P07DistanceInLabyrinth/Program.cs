using System;
using System.Collections.Generic;
using System.Linq;

namespace P07DistanceInLabyrinth
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            int startRow = 0;
            int startCol = 0;
            const int startIndex = -2;
            const int stopIndex = -1;
            const int zeroIndex = 0;

            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    var character = row[col];
                    if (character == '*')
                    {
                        startRow = i;
                        startCol = col;
                        matrix[i, col] = startIndex;
                    }
                    else
                    {
                        if (character == 'x')
                        {
                            matrix[i, col] = stopIndex;
                        }
                        else if (character == '0')
                        {
                            matrix[i, col] = zeroIndex;
                        }
                    }
                }
            }
            // Main
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell(startRow, startCol));
            matrix[startRow, startCol] = 0;

            while (queue.Count > 0)
            {
                Cell current = queue.Dequeue();

                if (current.Row + 1 < size && matrix[current.Row + 1, current.Col] == 0)
                {
                    queue.Enqueue(new Cell(current.Row + 1, current.Col));
                    matrix[current.Row + 1, current.Col] += matrix[current.Row, current.Col] + 1;
                }

                if (current.Row - 1 >= 0 && matrix[current.Row - 1, current.Col] == 0)
                {
                    queue.Enqueue(new Cell(current.Row - 1, current.Col));
                    matrix[current.Row - 1, current.Col] += matrix[current.Row, current.Col] + 1;
                }

                if (current.Col + 1 < size && matrix[current.Row, current.Col + 1] == 0)
                {
                    queue.Enqueue(new Cell(current.Row, current.Col + 1));
                    matrix[current.Row, current.Col + 1] += matrix[current.Row, current.Col] + 1;
                }

                if (current.Col - 1 >= 0 && matrix[current.Row, current.Col - 1] == 0)
                {
                    queue.Enqueue(new Cell(current.Row, current.Col - 1));
                    matrix[current.Row, current.Col - 1] += matrix[current.Row, current.Col] + 1;
                }
            }
            matrix[startRow, startCol] = startIndex;

            // Print Matrix
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int value = matrix[i, j];
                    switch (value)
                    {
                        case stopIndex:
                            Console.Write('x');
                            break;
                        case startIndex:
                            Console.Write('*');
                            break;
                        case zeroIndex:
                            Console.Write('u');
                            break;
                        default:
                            Console.Write(value);
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public int Col { get; set; }
        public int Row { get; set; }
    }
}
