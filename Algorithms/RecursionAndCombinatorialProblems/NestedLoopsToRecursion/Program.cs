using System;

namespace NestedLoopsToRecursion
{
    class Program
    {
        private static int[] arr;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            arr = new int[n];
            NestedLoop(0);
        }

        private static void NestedLoop(int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                NestedLoop(index + 1);
            }
        }
    }
}
