using System;
using System.Linq;

namespace SearchingSortingAndGreedyAlgorithms
{
    class Program
    {
        static void Main()
        {
            var numbers = new int[] { -131, -5, -3, 0, 1, 3, 4, 5, 6, 7, 9, 11, 15, 123, 133, 154 };
            var number = 154;
            Array.Sort(numbers);
            Console.WriteLine(LinearSearch(numbers, number));
            Console.WriteLine(BinarySearch(numbers, number));
            Console.WriteLine(BinarySearchReturnIndex(numbers, number));
            Console.WriteLine(Array.IndexOf(numbers, number));
        }

        private static int BinarySearchReturnIndex(int[] numbers, int number)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] == number)
                {
                    return mid;
                }
                else if (number > numbers[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        private static bool BinarySearch(int[] numbers, int number)
        {
            if (numbers.Length == 1 && number != numbers[0])
            {
                return false;
            }
            int middleIndex = numbers.Length / 2;
            int middleNumber = numbers[middleIndex];
            if (middleNumber == number)
            {
                return true;
            }
            else if (number > middleNumber)
            {
                var halfedArray = numbers.Skip(middleIndex).ToArray();
                return BinarySearch(halfedArray, number);
            }
            else
            {
                var halfedArray = numbers.SkipLast(middleIndex).ToArray();
                return BinarySearch(halfedArray, number);
            }
        }

        private static bool LinearSearch(int[] numbers, int number)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (number == numbers[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
