using System;
using System.Linq;
using System.Text;

namespace P02SortWords
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().ToList();

            var sortedArray = input.OrderBy(x => x);

            StringBuilder sb = new StringBuilder();
            foreach (var word in sortedArray)
            {
                sb.Append($"{word} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
