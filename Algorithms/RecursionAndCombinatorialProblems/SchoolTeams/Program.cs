using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTeams
{
    public class Program
    {
        static void Main()
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsComb = new string[3];
            var girlsCombs = new List<string[]>();
            var boys = Console.ReadLine().Split(", ");
            var boysComb = new string[2];
            var boysCombs = new List<string[]>();

            GenCombinations(0, 0, girls, girlsComb, girlsCombs);
            GenCombinations(0, 0, boys, boysComb, boysCombs);
            PrintAllCombinations(girlsCombs, boysCombs);
        }

        private static void PrintAllCombinations(List<string[]> girlsCombs, List<string[]> boysCombs)
        {
            foreach (var girlsComb in girlsCombs)
            {
                foreach (var boysComb in boysCombs)
                {
                    Console.WriteLine($"{String.Join(", ", girlsComb)}, {string.Join(", ", boysComb)}");
                }
            }
        }

        private static void GenCombinations(int index, int firstElement, string[] elements, string[] combination, List<string[]> combinationsList)
        {
            if (index >= combination.Length)
            {
                combinationsList.Add(combination.ToArray());
                return;
            }

            for (int i = firstElement; i < elements.Length; i++)
            {
                combination[index] = elements[i];
                GenCombinations(index + 1, i + 1, elements, combination, combinationsList);
            }
        }
    }
}
