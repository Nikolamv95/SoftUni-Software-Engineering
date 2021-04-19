using System;
using Xunit;

namespace WebProjectExample.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var a = 1;
            var b = 2;

            // Act
            var sum = a + b;

            // Assert
            Assert.Equal(3, sum);
        }

        // The test could throw an exception if the method is not working
        [Fact]
        public void Test2()
        {
            // Arrange
            var a = 1;
            var b = 2;

            // Act
            var sum = a + b / 0;

            // Assert
            Assert.Equal(3, sum);
        }

        // We test the result + if the exception will be thrown
        [Fact]
        public void Test3()
        {
            // Arrange
            var a = 1;
            var b = 2;

            // Act
            // If this operation didn't throw an exception so the test will fail
            Assert.Throws<DivideByZeroException>((() => a + b / 0));
            var sum = a + b;

            // Assert
            Assert.Equal(3, sum);
        }
    }
}
