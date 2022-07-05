using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    // input    
    // 1 3 5 7 9 11 20 30 40
    // 6
    // 20
    // 1 5 20 30
    // 3 7 20 30 40
    // 9 30
    // 11 20 30 40
    // 3 7 40
    class Program
    {
        static void Main()
        {
            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            var n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                var set = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(set);
            }

            var selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var set = sets
                    .OrderByDescending(x => x.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(set);

                sets.Remove(set);

                foreach (var element in set)
                {
                    universe.Remove(element);
                }
            }

            Console.WriteLine(selectedSets.Count);

            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(" ", set));
            }
        }
    }
}
