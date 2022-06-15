using System;

namespace RecursionAndCombinatorialProblems
{
    class Program
    {
        static void Main()
        {
            var array = Console.ReadLine().Split();

            ReverseArray(array, 0);

            Console.WriteLine(String.Join(" ", array));
        }

        private static void ReverseArray(string[] array, int index)
        {
            if (index == array.Length / 2)
            {
                return;
            }

            Swap(array, index);
            ReverseArray(array, index + 1);
            // without recoursion
            //var result = new string[array.Length];
            //int count = 0;
            //for (int i = array.Length - 1; i >= 0; i--)
            //{
            //    result[count++] = array[i];
            //}
            //return result;
        }

        private static void Swap(string[] array, int index)
        {
            var temp = array[index];
            array[index] = array[array.Length - index - 1];
            array[array.Length - index - 1] = temp;
        }
    }
}
