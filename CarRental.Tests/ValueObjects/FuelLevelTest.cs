using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;

namespace CarRental.Tests.ValueObjects
{
    public class FuelLevelTest
    {
        [Theory]
        [InlineData(-0.1F)]
        [InlineData(1.1F)]

        public void Create_ShouldThrowException_WithNegativeNumber_Or_WithNumberAbove_1(float value)
        {
            Assert.Throws<ValidationException>(() => FuelLevel.Create(value));
        }


        [Fact]
        public void Create_ShouldReturn_Valid_Object()
        {
            // Arrange
            float fuel = 0.5F;
            var o1 = FuelLevel.Create(fuel);

            // Act
            Assert.NotNull(o1);

            // Assert
            Assert.Equal(fuel, o1.LevelOfFuel);

        }
    }
}
