
namespace Tests
{
    using System;
    using System.Linq;
    using Database;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4);
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);
            //Act
            var expectedResult = 16;
            var actualResult = database.Count;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfThereAreMoreThan16Elements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 17).ToArray();
            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => new Database(numbers));
        }

        [Test]
        public void AddOperationShouldAddElementsOnNextFreeCell()
        {
            //Arrage
            int[] numbers = Enumerable.Range(1, 15).ToArray();
            Database database = new Database(numbers);
            //Act
            database.Add(16);
            var array = database.Fetch();
            var actualResult = array[database.Count - 1];
            var expectedResult = 16;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void IfThereAre1ElementsInTheDatabaseTryToAdd17()
        {
            //Arrage
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);
            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void RemoveLastIndexOperation()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);
            //Assert
            database.Remove();
            //Assert
            var expectedResult = 15;
            var actualResult = database.Fetch()[database.Count - 1];

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ExceptionRemoveElementFromEmptyDatabase()
        {
            //Arrage
            int[] numbers = new int[0];
            Database database = new Database(numbers);
            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnTheElementsAsArray()
        {
            //Arrage
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);
            //Act
            var allItems = database.Fetch();
            //Assert
            CollectionAssert.AreEqual(numbers, allItems);
        }
    }
}
