using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.ValueObjects
{
    public class DriverLicenseNumberTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("12345")]
        public void Create_DriverLicenseNumber_ShouldThrowException_WhenNull_Or_EmptyString_Or_Lees_Then10_Chars(string? value)
        {
            Assert.Throws<InvalidDriverLicenseException>(() => DriverLicenseNumber.Create(value));
        }

        [Fact]
        public void Create_DriverLicenseNumber_With_Valid_Parameter_Should_Return_Object()
        {
            // Arrange
            string driverLicenseNumber = "1234567890";
            var o1 = DriverLicenseNumber.Create(driverLicenseNumber);

            // Act
            Assert.NotNull(o1);

            // Assert
            Assert.Equal(driverLicenseNumber, o1.DriverLicenseNum);

        }
    }
}
