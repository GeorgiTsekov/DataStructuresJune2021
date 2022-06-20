using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    class Program
    {
        static void Main()
        {
            var coins = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .OrderByDescending(x => x));

            int target = int.Parse(Console.ReadLine());
            var result = new Dictionary<int, int>();
            
            while (target > 0 && coins.Count > 0)
            {
                int coin = coins.Dequeue();
                int countOfCoin = target / coin;

                if (countOfCoin > 0)
                {
                    target %= coin;
                    result.Add(coin, countOfCoin);
                }       
            }

            if (target == 0)
            {
                Console.WriteLine(result.Values.Sum());
                foreach (var kvp in result)
                {
                    Console.WriteLine($"{kvp.Value} X {kvp.Key} = {kvp.Key * kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("Can't do it");
            }
        }
    }
}
