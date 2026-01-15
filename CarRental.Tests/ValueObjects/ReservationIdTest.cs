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
    public class ReservationIdTest
    {
        [Fact]
        public void Create_WithValidGuid_ShouldRetournReservationId()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 
            var reservationId = ReservationId.Create(guid);

            // Assert
            reservationId.IdReservation.Should().Be(guid);

        }

        [Fact]
        public void Create_WithEmptyGuid_ShouldThrowException()
        {
            // Arrange
            var guid = Guid.Empty;

            // Assert
            Assert.Throws<ValidationException>(() => ReservationId.Create(guid));

        }

        [Fact]
        public void TwoDifferentInstances_WithSameGuid_ShouldBeEqual()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 
            var obj1 = ReservationId.Create(guid);
            var obj2 = ReservationId.Create(guid);
            // Assert

            obj1.Should().Be(obj2);

        }
    }
}
