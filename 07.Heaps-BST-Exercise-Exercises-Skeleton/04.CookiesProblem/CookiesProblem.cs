using Magnum.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var bag = new OrderedBag<int>(cookies);
            var steps = 0;

            var smallestElement = bag.GetFirst();

            while (bag.Count > 1 && smallestElement < k)
            {
                var firstCookie = bag.RemoveFirst();
                var secondCookie = bag.RemoveFirst();

                steps++;
                bag.Add(firstCookie + secondCookie * 2);
                smallestElement = bag.GetFirst();
            }

            return smallestElement >= k ? steps : -1;
        }
    }
}
