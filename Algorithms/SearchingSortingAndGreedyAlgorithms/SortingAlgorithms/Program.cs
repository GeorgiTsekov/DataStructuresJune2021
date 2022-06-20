using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            //SelectionSort(numbers); 
            //BubbleSort(numbers);
            //InsertionSort(numbers);
            //QuickSort(numbers, 0, numbers.Length - 1);
            int[] sorted = MergeSort(numbers);

            Console.WriteLine(String.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }
            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var mergedArr = new int[left.Length + right.Length];
            int mergedIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;
            
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    mergedArr[mergedIndex++] = left[leftIndex++];
                }
                else
                {
                    mergedArr[mergedIndex++] = right[rightIndex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                mergedArr[mergedIndex++] = left[i];
            }

            for (int i = rightIndex; i < right.Length; i++)
            {
                mergedArr[mergedIndex++] = right[i];
            }

            return mergedArr;
        }

        private static void QuickSort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivot = startIndex;
            int left = startIndex + 1;
            int right = endIndex;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left++;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right--;
                }
            }

            Swap(numbers, pivot, right);

            if (startIndex + right - 1 > right + 1 + endIndex)
            {
                QuickSort(numbers, startIndex, right - 1);
                QuickSort(numbers, right + 1, endIndex);
            }
            else
            {
                QuickSort(numbers, right + 1, endIndex);
                QuickSort(numbers, startIndex, right - 1);
            }
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i - 1;
                while (j > 0 && (numbers[j - 1] > numbers[j]))
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
            }
        }

        private static void BubbleSort(int[] numbers)
        {
            var sortedCount = 0;
            var isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < numbers.Length - sortedCount; j++)
                {
                    var i = j - 1;
                    if (numbers[i] > numbers[j])
                    {
                        Swap(numbers, i, j);
                        isSorted = false;
                    }
                }

                sortedCount++;
            }
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                Swap(numbers, i, min);
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
