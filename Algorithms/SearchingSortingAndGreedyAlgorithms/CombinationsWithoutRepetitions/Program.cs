using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinationsWithoutRepetitions
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().ToList();
            int n = int.Parse(Console.ReadLine());

            var list = input.Select(x => x.ToString()).ToList();
            var result = GetPermutations(list, n);
            foreach (var perm in result)
            {
                foreach (var c in perm)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }

    }
}
