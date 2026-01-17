using CarRental.Domain.Policies;
using CarRental.Domain.ValueObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.Policies
{
    public class LongTermDiscountPolicyTests
    {

        [Theory]
        [InlineData(7, 1000, 0)]  // 7 days - no discount
        [InlineData(8, 1000, 100)] // 8 days - 10% discount
        public void CalculateDiscount_ShouldReturnCorrectAmount(int days, decimal basePriceAmount, decimal expectedDiscount)
        {
            // Arrange
            var sut = new LongTermDiscountPolicy();
            var basePrice = Money.Of(basePriceAmount);

            // Act
            var result = sut.CalculateDiscount(basePrice, days);

            // Assert
            result.Amount.Should().Be(expectedDiscount);

        }
    }
}
