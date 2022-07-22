using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinationsAndRepetitions
{
    class Program
    {
        private static List<Stack<int>> combinations;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            combinations = new List<Stack<int>>();
            NestedLoops(new Stack<int>(), 0, k, n);
        }

        private static void NestedLoops(Stack<int> stack, int index, int n, int k)
        {
            if (n == index)
            {
                bool isSame = true;
                var combination = combinations.FirstOrDefault(x => x.Sum() == stack.Sum() && x.Max() == stack.Max() && x.Min() == stack.Min());
                if (combination != null)
                {
                    var comb = new List<int>(combination);
                    foreach (var number in stack)
                    {
                        if (comb.Any(x => x == number))
                        {
                            comb.Remove(number);
                        }
                        else
                        {
                            isSame = false;
                            break;
                        }


                        if (!isSame)
                        {
                            break;
                        }
                    }

                    if (isSame)
                    {
                        return;
                    }
                }

                combinations.Add(new Stack<int>(stack));

                Console.WriteLine(string.Join(" ", stack));
                return;
            }

            for (int i = 1; i <= k; i++)
            {
                stack.Push(i);
                NestedLoops(stack, index + 1, n, k);
                stack.Pop();
            }
        }
    }
}
