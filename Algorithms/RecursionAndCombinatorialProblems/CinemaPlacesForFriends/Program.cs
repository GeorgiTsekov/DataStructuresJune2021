using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaPlacesForFriends
{
    class Program
    {
        private static List<string> friends;
        private static string[] staticFriends;
        private static bool[] locked;

        static void Main()
        {
            friends = Console.ReadLine().Split(", ").ToList();
            staticFriends = new string[friends.Count];
            locked = new bool[friends.Count];

            string input = Console.ReadLine();
            while (input != "generate")
            {
                var splitedInput = input.Split(" - ");
                string name = splitedInput[0];
                int position = int.Parse(splitedInput[1]) - 1;

                if (staticFriends.Contains(name))
                {
                    Console.WriteLine($"{name} doesn't exist in the collection of friends!");
                    return;
                }

                if (locked[position])
                {
                    Console.WriteLine($"2 friends want equal places!");
                    return;
                }

                staticFriends[position] = name;
                locked[position] = true;
                friends.Remove(name);

                input = Console.ReadLine();
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= friends.Count)
            {
                PrintFriends();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < friends.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i); 
            }
        }

        private static void PrintFriends()
        {
            int indexOfFriends = 0;
            var sb = new StringBuilder();
            for (int i = 0; i < staticFriends.Length; i++)
            {
                if (locked[i])
                {
                    sb.Append(staticFriends[i] + " ");
                }
                else
                {
                    sb.Append(friends[indexOfFriends++] + " ");
                }
            }

            Console.WriteLine(String.Join(" ", sb.ToString().TrimEnd()));
        }

        private static void Swap(int first, int second)
        {
            var temp = friends[first];
            friends[first] = friends[second];
            friends[second] = temp;
        }
    }
}
