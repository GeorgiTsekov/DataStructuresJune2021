namespace GreedyFractionalKnapsackProblem
{
    public class Item
    {
        public Item(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price { get; set; }

        public double Weight { get; set; }
    }
}
