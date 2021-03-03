using NUnit.Framework;

namespace Demo2.Test
{
    public class PersonTest
    {
        [TestFixture]
        public class PersonTest2
        {
            [Test]
            public void DoesMyNameWorks()
            {
                //Arrange
                Person person = new Person("Maria", 10m);
                
                //Act
                var expectedMoney = $"My money are 10";
                var existingMoney = person.GetSavedMoney();
                
                //Assert
                Assert.AreEqual(expectedMoney, existingMoney);

                //AAA this is 3-A pattern Arrange, Act, Assert
            }
        }
    }
}
