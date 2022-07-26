using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyFractionalKnapsackProblem
{
    class Program
    {
        private static List<Item> priceWeightCollection;
        private static double totalPrice = 0;
        static void Main()
        {
            priceWeightCollection = new List<Item>();
            double capacity = int.Parse(Console.ReadLine());
            int items = int.Parse(Console.ReadLine());
            for (int i = 0; i < items; i++)
            {
                var splitedInput = Console.ReadLine().Split(" -> ").Select(double.Parse).ToArray();

                double price = splitedInput[0];
                double weight = splitedInput[1];
                var item = new Item(price, weight);

                priceWeightCollection.Add(item);
            }

            Solve(capacity);
        }

        private static void Solve(double capacity)
        {
            priceWeightCollection = priceWeightCollection.OrderByDescending(x => (x.Price / x.Weight)).ToList();

            foreach (var item in priceWeightCollection)
            {
                if (capacity <= 0)
                {
                    break;
                }

                if (item.Weight <= capacity)
                {
                    capacity -= item.Weight;
                    Console.WriteLine($"Take 100% of item with price {item.Price:F2} and weight {item.Weight:F2}");
                    totalPrice += item.Price;
                }
                else
                {
                    var percent = ((double)capacity / (double)item.Weight);
                    totalPrice += item.Price * percent;
                    Console.WriteLine($"Take {(percent * 100):F2}% of item with price {item.Price:F2} and weight {item.Weight:F2}");
                    capacity = 0;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
