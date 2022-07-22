using System;

namespace ShuffleAlgorithm
{
    class Program
    {
        static void Main()
        {
            var array = new int[] { 1, 2, 3, 4, 10, 55, -2, 55 };
            var shuffledArr = Shuffle(array);
            Console.WriteLine(string.Join(", ", shuffledArr));
        }

        private static int[] Shuffle(int[] array)
        {
            var random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                var i1 = random.Next(array.Length);
                var i2 = random.Next(array.Length);

                var temp = array[i1];
                array[i1] = array[i2];
                array[i2] = temp;
            }

            return array;
        }
    }
}
