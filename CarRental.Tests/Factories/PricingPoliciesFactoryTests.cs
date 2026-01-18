using CarRental.Domain.Enums;
using CarRental.Domain.Factories;
using CarRental.Domain.Policies;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.Factories
{
    public class PricingPoliciesFactoryTests
    {
        [Fact]
        public void CreatePricingStrategy_ShouldReturnPremiumStrategy_ForPremiumCar()
        {
            // Arrange
            var sut = new PricingPoliciesFactory();

            // Act
            var result = sut.CreatePricingStrategy(VehicleClass.Premium);

            // Assert
            result.Should().BeOfType<PremiumPricingStrategy>();
        }

        [Theory]
        [InlineData(VehicleClass.Basic)]
        [InlineData(VehicleClass.Standard)]
        public void CreatePricingStrategy_ShouldReturnStandardStrategy_ForNonPremiumCars(VehicleClass vehicleClass)
        {
            // Arrange
            var sut = new PricingPoliciesFactory();

            // Act
            var result = sut.CreatePricingStrategy(vehicleClass);

            // Assert
            result.Should().BeOfType<StandardPricingStrategy>();
        }
    }
}
