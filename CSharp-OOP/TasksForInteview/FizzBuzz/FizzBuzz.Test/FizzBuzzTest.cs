using FizzBuzz.Contracts;
using FizzBuzz.Test.Fake;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Test
{
    public class FizzBuzzTest
    {
        private FakeConsoleWriter writer;
        private FizzBuzz fizzBuzz;

        [SetUp]
        public void Setup()
        {
            this.writer = new FakeConsoleWriter();
            this.fizzBuzz = new FizzBuzz(this.writer);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre1to2ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(1, 2);
            Assert.AreEqual("12", writer.Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre1to3ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(1, 3);
            Assert.AreEqual("12fizz", writer.Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre4to6ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(4, 6);
            Assert.AreEqual("4buzzfizz", writer.Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre14to17ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(14, 17);
            Assert.AreEqual("14fizzbuzz1617", writer.Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAreMinus5to2ThenResultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(-5, 2);
            Assert.AreEqual("12", writer.Result);
        }
    }
}