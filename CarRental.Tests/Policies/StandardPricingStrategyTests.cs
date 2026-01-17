using CarRental.Domain.Enums;
using CarRental.Domain.Policies;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.Policies
{
    public class StandardPricingStrategyTests
    {
        [Theory]
        [InlineData(VehicleClass.Basic, 1, 100)]    // Basic = 100m per day
        [InlineData(VehicleClass.Standard, 2, 400)] // Standard = 200m per day
        [InlineData(VehicleClass.Premium, 3, 900)]  // Premium = 300m per day
        public void CalculateBasePrice_ShouldReturnCorrectAmount_ForCarClass(VehicleClass vehicleClass, int days, decimal expected)
        {
            // Arrange 
            var sut = new StandardPricingStrategy();

            // Act
            var result = sut.CalculateBasePrice(vehicleClass, days);

            // Assert

            result.Amount.Should().Be(expected);

 
        }
    }
}
