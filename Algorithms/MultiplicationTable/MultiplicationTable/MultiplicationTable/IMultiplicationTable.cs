namespace MultiplicationTable
{
    public interface IMultiplicationTable
    {
        int Number { get; set; }

        string MultiplicateFirstNPrimeNumbers();

        public void Print(string result);
    }
}
