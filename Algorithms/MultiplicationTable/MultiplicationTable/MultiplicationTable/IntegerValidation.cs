using System;

namespace MultiplicationTable
{
    public class IntegerValidation : IIntegerValidation
    {
        public int IsValid(string n)
        {
            if (String.IsNullOrWhiteSpace(n))
            {
                throw new NullReferenceException("The number cannot be null or whitespace!");
            }
            bool isInteger = Int32.TryParse(n, out int result);

            if (!isInteger)
            {
                throw new ArgumentException("The number shout be positive Integer!");
            }

            return result;
        }
    }
}
