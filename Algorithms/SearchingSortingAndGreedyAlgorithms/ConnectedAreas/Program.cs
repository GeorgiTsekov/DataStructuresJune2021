using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreas
{
    class Program
    {
        private static char[,] matrix;
        private static List<Area> areas;
        private static int size;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            areas = new List<Area>();
            InputCoordiantes();
            FindConnectedAreas();
            Print();
        }

        private static void Print()
        {
            Console.WriteLine($"Total areas found: {areas.Count}");
            int count = 0;
            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{++count} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void FindConnectedAreas()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    size = 0;
                    ExploreArea(i, j);

                    if (size > 0)
                    {
                        var area = new Area(i, j, size);
                        areas.Add(area);
                    }
                }
            }
        }

        private static void InputCoordiantes()
        {
            while (true)
            {
                Console.WriteLine("Add coordinates with walls like 0 0: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "stop")
                {
                    break;
                }

                var coordinates = input.Split(" ").Select(int.Parse).ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (AreOutside(row, col))
                {
                    continue;
                }

                matrix[row, col] = '*';
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (AreOutside(row, col) || matrix[row, col] == '*'  || matrix[row, col] == 'v')
            {
                return;
            }

            matrix[row, col] = 'v';

            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);

            size++;
        }

        private static bool AreOutside(int row, int col)
        {
            if (matrix.GetLength(0) <= row || matrix.GetLength(1) <= col || col < 0 || row < 0)
            {
                return true;
            }

            return false;
        }
    }
}
