using System;

namespace ReversedArray
{
    class Program
    {
        private static int[] arr;
        static void Main()
        {
            arr = new int[] { 1, 2, 3, 5, 10, 4, 9 };

            ReverseArray(0, arr.Length - 1);
            Console.WriteLine(string.Join(", ", arr));
        }

        private static int[] ReverseArray(int start, int end)
        {
            if (start >= end)
            {
                return arr;
            }

            Swap(start, end);

            return ReverseArray(start + 1, end - 1);
        }

        private static void Swap(int start, int end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }
    }
}
