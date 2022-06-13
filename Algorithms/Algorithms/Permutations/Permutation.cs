namespace Permutations
{
    public class Permutation
    {
        private static string[] elements;

        public Permutation(string[] elementsArray)
        {
            elements = new string[elementsArray.Length];
            elements = elementsArray;
        }

        public void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            var usedElements = new HashSet<string> { elements[index]};

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!usedElements.Contains(elements[i]))
                {
                    SwapElementsInTheArray(index, i);
                    Permute(index + 1);
                    SwapElementsInTheArray(index, i);

                    usedElements.Add(elements[i]);
                }
            }
        }

        private static void SwapElementsInTheArray(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
