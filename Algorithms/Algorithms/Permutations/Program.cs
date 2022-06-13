namespace Permutations 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var arrayOfLetters = Console.ReadLine().Split(" ");
            Permutation permutation = new Permutation(arrayOfLetters);

            permutation.Permute(0);
        }
    }
}