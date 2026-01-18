using CarRental.Domain.Enums;
using CarRental.Domain.Policies;
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
    public class PricingServiceTests
    {
        private readonly Mock<IPricingStrategy> _pricingStrategyMock;
        private readonly Mock<IDepositPolicy> _depositPolicyMock;
        private readonly Mock<IDiscountPolicy> _discountPolicyMock;

        // SUT 
        private readonly PricingService _service;

        public PricingServiceTests()
        {
            _pricingStrategyMock = new Mock<IPricingStrategy>();
            _depositPolicyMock = new Mock<IDepositPolicy>();
            _discountPolicyMock = new Mock<IDiscountPolicy>();

            _service = new PricingService
                (
                _pricingStrategyMock.Object,
                _depositPolicyMock.Object,
                _discountPolicyMock.Object
                );
        }


        [Fact]

        public void CalculatePrice_ShouldAggreggateAllComponentsCorrectly()
        {
            // Arrange
            var vehicleClass = VehicleClass.Standard;
            var days = 10;

            // Baseprice = 2000, Deposit = 1000, Discount = 200 (more then 7 days 10% discount)

            _pricingStrategyMock
                .Setup(x => x.CalculateBasePrice(vehicleClass, days))
                .Returns(Money.Of(2000));

            _depositPolicyMock
                .Setup(x => x.CalculateDeposit(vehicleClass))
                .Returns(Money.Of(1000));

            _discountPolicyMock
                .Setup(x => x.CalculateDiscount(Money.Of(2000), days))
                .Returns(Money.Of(200));


            // Act
            var result = _service.CalculatePrice(vehicleClass, days);



            // Assert
            result.BasePrice.Amount.Should().Be(2000);
            result.Deposit.Amount.Should().Be(1000);
            result.Discount.Amount.Should().Be(200);
            result.FinalAmount.Amount.Should().Be(1800);

        }

    }
}
