using CarRental.Domain.Enums;
using CarRental.Domain.Policies;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.Policies
{
    public class StandardDepositPolicyTests
    {
        [Theory]
        [InlineData(VehicleClass.Basic, 500)]
        [InlineData(VehicleClass.Standard, 1000)]
        [InlineData(VehicleClass.Premium, 1500)]

        public void CalculateDeposit_ShouldReturnCorrectAmount(VehicleClass vehicleClass, decimal expected)
        {
            // Arrange 
            var sut = new StandardDepositPolicy();

            // Act
            var result = sut.CalculateDeposit(vehicleClass);

            // Assert

            result.Amount.Should().Be(expected);
        }

    }
}
