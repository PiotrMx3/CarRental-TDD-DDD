using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using FluentAssertions;


namespace CarRental.Tests.ValueObjects
{
    public class VehicleIdTests
    {
        [Fact]
        public void Create_WithValidGuid_ShouldRetournVechicleId()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 

            var vechicleId = VehicleId.Create(guid);

            // Assert
            vechicleId.IdVehicle.Should().Be(guid);

        }

        [Fact]
        public void Create_WithEmptyGuid_ShouldThrowException()
        {
            // Arrange
            var guid = Guid.Empty;

            // Assert
            Assert.Throws<ValidationException>(() => VehicleId.Create(guid));

        }

        [Fact]
        public void TwoDifferentInstances_WithSameGuid_ShouldBeEqual()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 
            var obj1 = VehicleId.Create(guid);
            var obj2 = VehicleId.Create(guid);
            // Assert

            obj1.Should().Be(obj2);

        }


    }
}
