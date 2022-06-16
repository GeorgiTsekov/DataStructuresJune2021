﻿using System;
using System.Collections.Generic;

namespace WordCruncher
{
    public class Program
    {
        private static string target;
        private static Dictionary<int, List<string>> wordsByIndex;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;

        public static void Main()
        {
            var words = Console.ReadLine().Split(", ");

            target = Console.ReadLine();
            wordsByIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();
            foreach (var word in words)
            {
                var index = target.IndexOf(word);

                if (index == -1)
                {
                    continue;
                }

                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }

                wordsCount[word]++;

                while (index != -1)
                {
                    if (!wordsByIndex.ContainsKey(index))
                    {
                        wordsByIndex.Add(index, new List<string>());
                    }

                    wordsByIndex[index].Add(word);

                    index = target.IndexOf(word, index + 1);
                }
            }

            GenerateSolutions(0);
        }

        private static void GenerateSolutions(int index)
        {
            if (index == target.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            if (!wordsByIndex.ContainsKey(index))
            {
                return;
            }

            foreach (var word in wordsByIndex[index])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word] -= 1;
                usedWords.AddLast(word);

                GenerateSolutions(index + word.Length);

                usedWords.RemoveLast();
                wordsCount[word] += 1;
            }
        }
    }
}
