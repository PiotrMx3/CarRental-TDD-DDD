using CarRental.Domain.ValueObjects;
using CarRental.Domain.Exceptions;
using Xunit;

namespace CarRental.Tests.ValueObjects
{
    public class MoneyTest
    {
        [Fact]
        public void Of_ShouldCreateMoney_WhenAmountIsPositive()
        {
            // Arrange
            var money = Money.Of(100);

            // Act
            Assert.NotNull(money);

            // Assert
            Assert.Equal(100, money.Amount);
        }

        [Fact]

        public void Of_ShouldThrowException_WhenAmountIsNEgative()
        {
            Assert.Throws<InvalidMoneyAmountException>(() => Money.Of(-10));
        }

        [Fact] 

        public void Of_OperatorPlus_ShouldAddTwoMoneyObjects()
        {
            // Arrange
            var m1 = Money.Of(100);
            var m2 = Money.Of(50);

            // Act 
            var result = m1 + m2;

            // Assert
            Assert.Equal(150, result.Amount);
        }

    }
}
