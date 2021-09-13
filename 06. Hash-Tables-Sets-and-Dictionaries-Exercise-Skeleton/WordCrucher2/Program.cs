using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCrucher2
{
    class Program
    {
        private static HashSet<string> result = new HashSet<string>();

        static void Main()
        {
            List<string> syllables = Console.ReadLine().Split(", ").ToList();
            var targetWord = Console.ReadLine();

            WordCruncher(syllables, targetWord);

            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }

        private static void WordCruncher(List<string> syllables, string word, string currentResult = "")
        {
            var currentWord = currentResult.Replace(" ", null);

            if (currentWord == word)
            {
                result.Add(currentResult.TrimStart());
                return;
            }

            foreach (var syllable in syllables)
            {
                if (word.StartsWith(currentWord + syllable))
                {
                    List<string> startInput = new List<string>(syllables);
                    startInput.Remove(syllable);

                    WordCruncher(startInput, word, currentResult + " " + syllable);
                }
            }
        }
    }
}
