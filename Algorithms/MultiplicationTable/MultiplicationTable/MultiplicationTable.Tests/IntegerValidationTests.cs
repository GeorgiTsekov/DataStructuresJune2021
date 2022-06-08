using NUnit.Framework;
using System;

namespace MultiplicationTable.Tests
{
    [TestFixture]
    public class IntegerValidationTests
    {
        [TestCase("123")]
        [TestCase("0")]
        [TestCase("-1234")]
        public void IsValidMethodShouldReturnIntegerForValidInteger(string number)
        {
            var integerValidation = new IntegerValidation();
            int result = integerValidation.IsValid(number);
            Assert.AreEqual(result, int.Parse(number));
        }

        [TestCase]
        public void IsValidMethodShouldTrowAnExceptionForNull()
        {
            var integerValidation = new IntegerValidation();
            string numberAsString = null;

            Assert.Throws<NullReferenceException>(() => integerValidation.IsValid(numberAsString));
        }

        [TestCase("asdf")]
        [TestCase("13.51")]
        [TestCase("-313.51")]
        public void IsValidMethodShouldTrowAnExceptionForDecimalOrString(string number)
        {
            var integerValidation = new IntegerValidation();

            Assert.Throws<ArgumentException>(() => integerValidation.IsValid(number));
        }
    }
}
