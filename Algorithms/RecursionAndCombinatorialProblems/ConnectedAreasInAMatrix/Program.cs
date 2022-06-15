using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInAMatrix
{
    class Program
    {
        private static char[,] matrix;
        private static int size;
        private const char VISITED = 'v';
        private static List<Area> areas;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            areas = new List<Area>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var colElements = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    size = 0;
                    ExploreArea(i, j);
                    if (size != 0)
                    {
                        var area = new Area(i, j, size);
                        areas.Add(area);
                    }
                }
            }

            areas = areas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col).ToList();
            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row, col))
            {
                return;
            }

            if (matrix[row, col] == VISITED || matrix[row, col] == '*')
            {
                return;
            }

            matrix[row, col] = VISITED;

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);

            size++;
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);
        }
    }
}
