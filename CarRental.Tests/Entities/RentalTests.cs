using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRental.Tests.Entities
{
    public class RentalTests
    {

        private Rental CreateRental()
        {
            return Rental.Create(
                RentalId.New(), 
                ReservationId.New(), 
                VehicleId.New(), 
                CustomerId.New(), 
                DateRange.Create(DateTime.Today, DateTime.Today.AddDays(1)), 
                Money.Of(300)
            );
        }

        [Fact]
        public void Create_ShouldInitializeRental_WithOngoinStatus_AndPrice()
        {
            // Arrange 
            var id = RentalId.New();
            var reservationId = ReservationId.New();
            var vehicleId = VehicleId.New();
            var custoemrId = CustomerId.New();

            var today = DateTime.UtcNow.Date;
            var range = DateRange.Create(today, today.AddDays(3));
            var price = Money.Of(300);


            // Act 
            var rental = Rental.Create(id, reservationId, vehicleId, custoemrId, range, price);


            // Assert

            rental.CustomerId.Should().Be(custoemrId);
            rental.Status.Should().Be(RentalStatus.Ongoing);
            rental.PriceToPay.Should().Be(price);
            rental.IsReturned.Should().BeFalse();

        }

        [Fact]
        public void Return_ShouldSucceed_WhenRentalIsOngoing()
        {
            // Arrange
            var rental = CreateRental();
            var returnDate = DateTime.UtcNow;

            // Act
            rental.Return(returnDate);

            // Assert

            rental.Status.Should().Be(RentalStatus.Returned);
            rental.ReturnedAt.Should().Be(returnDate);
            rental.IsReturned.Should().BeTrue();
        }

        [Fact]
        public void Return_ShouldThrow_WhenRentalIsAlreadyReturned()
        {
            // Arrange
            var rental = CreateRental();
            rental.Return(DateTime.UtcNow);

            // Act
            Action action = () => rental.Return(DateTime.UtcNow.AddHours(1));

            // Assert
            action.Should().Throw<DomainException>()
                .WithMessage("Rental is already returned.");
        }
    }
}
