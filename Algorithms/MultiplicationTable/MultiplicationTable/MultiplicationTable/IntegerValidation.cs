using System;
using System.Linq;

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

            if (n.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("The number shout be Integer!");
            }

            int number = int.Parse(n);

            return number;
        }
    }
}
