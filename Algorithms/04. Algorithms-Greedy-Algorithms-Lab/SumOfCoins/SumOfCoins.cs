namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main()
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50, 500, 1500, 1000000, 21329, 839859, 03811 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins
                .Where(x => x <= targetSum)
                .OrderByDescending(x => x)
                .ToList();

            var coinsDict = new Dictionary<int, int>();
            bool isFinished = false;

            foreach (var coin in sortedCoins)
            {
                int remaining = targetSum % coin;
                int remainingSum = (int)(targetSum / coin);
                if (remaining == 0)
                {
                    coinsDict.Add(coin, remainingSum);
                    isFinished = true;
                    break;
                }
                else
                {
                    if (remainingSum > 0)
                    {
                        coinsDict.Add(coin, remainingSum);
                        targetSum = remaining;
                    }
                }
            }

            if (isFinished)
            {
                return coinsDict;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}