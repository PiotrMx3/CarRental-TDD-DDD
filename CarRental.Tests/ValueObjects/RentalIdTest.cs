using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.ValueObjects
{
    public class RentalIdTest
    {
        [Fact]
        public void Create_WithValidGuid_ShouldRetournRentalId()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 

            var rentalId = RentalId.Create(guid);

            // Assert
            rentalId.IdRental.Should().Be(guid);

        }

        [Fact]
        public void Create_WithEmptyGuid_ShouldThrowException()
        {
            // Arrange
            var guid = Guid.Empty;

            // Assert
            Assert.Throws<ValidationException>(() => RentalId.Create(guid));

        }

        [Fact]
        public void TwoDifferentInstances_WithSameGuid_ShouldBeEqual()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 
            var obj1 = RentalId.Create(guid);
            var obj2 = RentalId.Create(guid);
            // Assert

            obj1.Should().Be(obj2);

        }
    }
}
