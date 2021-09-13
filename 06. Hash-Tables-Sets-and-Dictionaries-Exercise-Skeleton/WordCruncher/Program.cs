using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    class Cruncher
    {
        private class Node
        {
            public Node(string syllable, List<Node> nextSyllables)
            {
                Syllable = syllable;
                NextSyllable = nextSyllables;
            }

            public string Syllable { get; set; }

            public List<Node> NextSyllable { get; set; }
        }

        private List<Node> syllableGroups;

        public Cruncher(string[] syllables, string targetWord)
        {
            this.syllableGroups = new List<Node>();
            this.syllableGroups = this.GenerateSyllableGroups(syllables, targetWord);
        }

        private List<Node> GenerateSyllableGroups(string[] syllables, string targetWord)
        {
            if (string.IsNullOrEmpty(targetWord) || syllables.Length == 0)
            {
                return null;
            }

            var resultValues = new List<Node>();

            for (int i = 0; i < syllables.Length; i++)
            {
                var syllable = syllables[i];

                if (targetWord.StartsWith(syllable))
                {
                    var nextSyllables = GenerateSyllableGroups(
                        syllables.Where((syll, index) => index != i).ToArray(),
                        targetWord.Substring(syllable.Length)
                    );

                    resultValues.Add(new Node(syllable, nextSyllables));
                }
            }

            return resultValues;
        }

        public HashSet<string> GetSyllablePath()
        {
            var allPaths = new List<List<string>>();
            ReconstructPaths(this.syllableGroups, new List<string>(), allPaths);
            return new HashSet<string>(allPaths.Select(list => String.Join(' ', list)));
        }

        private void ReconstructPaths(List<Node> nodes, List<string> currentPath, List<List<string>> allPaths)
        {
            if (nodes == null)
            {
                allPaths.Add(new List<string>(currentPath));
                return;
            }

            foreach (var node in nodes)
            {
                currentPath.Add(node.Syllable);

                ReconstructPaths(node.NextSyllable, currentPath, allPaths);

                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var syllables = Console.ReadLine().Split(", ");
            var targetWord = Console.ReadLine();

            var cruncher = new Cruncher(syllables, targetWord);

            foreach (var syllablePath in cruncher.GetSyllablePath())
            {
                Console.WriteLine(syllablePath);
            }
        }
    }
}
