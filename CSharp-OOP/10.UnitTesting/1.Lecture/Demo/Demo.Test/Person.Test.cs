using Demo;
using NUnit.Framework;

namespace DemoTest.Test
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void DoesMyNameWorks()
        {
            int number1 = 10;
            int number2 = 10;

            //Assert.AreEqual(number1, number2);
            Assert.That(() => number1 == number2);
        }
    }
}
