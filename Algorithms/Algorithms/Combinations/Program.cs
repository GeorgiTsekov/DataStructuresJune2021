﻿public class Program
{
    private static int k;
    private static string[] elements;
    private static string[] combinations;

    public static void Main(string[] args)
    {
        elements = Console.ReadLine().Split();
        k = int.Parse(Console.ReadLine());

        combinations = new string[k];

        Combinations(0, 0);
    }

    private static void Combinations(int index, int elementsStartIndex)
    {
        if (index >= combinations.Length)
        {
            Console.WriteLine(String.Join(" ", combinations));
            return;
        }

        for (int i = elementsStartIndex; i < elements.Length; i++)
        {
                combinations[index] = elements[i];
                Combinations(index + 1, i + 1);
        }
    }
}
