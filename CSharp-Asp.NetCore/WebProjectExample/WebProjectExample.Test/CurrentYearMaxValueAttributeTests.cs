using System;
using System.Collections.Generic;
using System.Text;
using WebProjectExample.ValidationAttributes;
using Xunit;

namespace WebProjectExample.Test
{
    public class CurrentYearMaxValueAttributeTests
    {
        [Fact]
        public void IsValidReturnsFalseForDateTimeYearsAfterCurrentYear()
        {
            // Arrange
            var attribute = new CurrentYearMaxValueAttribute(1990);

            // Act
            var isValid = attribute.IsValid(DateTime.UtcNow.AddYears(1));

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsFalseForIntYearsAfterCurrentYear()
        {
            // Arrange
            var attribute = new CurrentYearMaxValueAttribute(1990);

            // Act
            var isValid = attribute.IsValid(2022);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsTrueForIntYearsAfterCurrentYear()
        {
            // Arrange
            var attribute = new CurrentYearMaxValueAttribute(1990);

            // Act
            var isValid = attribute.IsValid(2021);

            // Assert
            Assert.True(isValid);
        }
    }
}
