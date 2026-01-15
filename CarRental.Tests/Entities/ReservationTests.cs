using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Abstractions;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using FluentAssertions;
using Moq;
using Xunit;
namespace CarRental.Tests.Entities
{
    public class ReservationTests
    {
        [Fact]
        public void Create_ShouldSucceed_WhenDateRangeIsInFuture()
        {
            // Arrange 
            var clockMock = new Mock<IClock>();
            var fixedDate = new DateTime(2024, 1, 1, 12, 0, 0);
            clockMock.Setup(c => c.Now()).Returns(fixedDate);

            var start = fixedDate.AddDays(10);
            var end = start.AddDays(5);

            var range = DateRange.Create(start, end);


            // Act
            var reservation = Reservation.Create(

                ReservationId.New(),
                range,
                VehicleId.New(),
                CustomerId.New(),
                clockMock.Object
                );

            // Assert

            reservation.Status.Should().Be(ReservationStatus.Pending);
            reservation.Duration.Should().Be(range);
            reservation.CreatedAt.Should().Be(fixedDate);
        }


        [Fact]

        public void Create_ShouldThrowException_WhenStartDateIsInPast()
        {
            // Arrange 
            var clockMock = new Mock<IClock>();
            var fixedDate = new DateTime(2024, 6, 1);
            clockMock.Setup(c => c.Now()).Returns(fixedDate);

            var start = fixedDate.AddDays(-1);
            var end = fixedDate.AddDays(2);

            var range = DateRange.Create(start, end);

            Action action = () => Reservation.Create(

                ReservationId.New(),
                range,
                VehicleId.New(),
                CustomerId.New(),
                clockMock.Object
                );

            Assert.Throws<ValidationException>(action);


        }

    }
}
