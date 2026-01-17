using CarRental.Domain.Abstractions.Repositories;
using CarRental.Domain.Entities;
using CarRental.Domain.Exceptions;
using CarRental.Domain.Services;
using CarRental.Domain.ValueObjects;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.Services
{
    public class AvailabilityServiceTests
    {
        private readonly Mock<IReservationRepository> _reservationRepoMock;
        private readonly AvailabilityService _service;

        public AvailabilityServiceTests()
        {
            _reservationRepoMock = new Mock<IReservationRepository>();

            _service = new AvailabilityService(_reservationRepoMock.Object);
        }

        [Fact]

        public void ValidateAvailability_ShouldNotThrow_WhenNoOverlappingReservations()
        {
            // Arrange 
            var vehicleId = VehicleId.New();
            var range = DateRange.Create(DateTime.Now.AddDays(1), DateTime.Now.AddDays(3));


            _reservationRepoMock.Setup(r => r.GetOverlappingReservations(vehicleId, range)).Returns(new List<Reservation>());

            // Act
            Action action = () => _service.ValidateAvailability(vehicleId, range);

            // Assert
            action.Should().NotThrow();
        }


        [Fact]
        public void ValidateAvailability_ShouldThrow_WhenConflictExists()
        {
            // Arrange
            var vehicleId = VehicleId.New();
            var range = DateRange.Create(DateTime.Now.AddDays(1), DateTime.Now.AddDays(3));


            var conflictingReservation = (Reservation)null!;

            _reservationRepoMock
                .Setup(r => r.GetOverlappingReservations(vehicleId, range))
                .Returns(new List<Reservation> { conflictingReservation });

            // Act
            Action action = () => _service.ValidateAvailability(vehicleId, range);

            // Assert
            action.Should().Throw<CarAlreadyBookedException>();
        }

    }
}
