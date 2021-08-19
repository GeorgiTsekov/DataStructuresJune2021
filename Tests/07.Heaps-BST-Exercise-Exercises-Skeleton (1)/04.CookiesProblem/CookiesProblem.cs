using _03.MinHeap;
using Magnum.Collections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var bag = new MinHeap<int>();
            foreach (var cookie in cookies)
            {
                bag.Add(cookie);
            }

            var smallestElement = bag.Peek();
            var steps = 0;

            while (bag.Size > 1 && smallestElement < k)
            {
                var leastSweetCookie = bag.Dequeue();
                var secondLeastSweetCookie = bag.Dequeue();

                steps++;
                bag.Add(leastSweetCookie + 2 * secondLeastSweetCookie);
                smallestElement = bag.Peek();
            }

            return smallestElement >= k ? steps : -1;
        }
    }
}
