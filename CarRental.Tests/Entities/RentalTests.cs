using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CarRental.Tests.Entities
{
    public class RentalTests
    {
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
            rental.IsReturned().Should().BeFalse();

        }
    }
}
