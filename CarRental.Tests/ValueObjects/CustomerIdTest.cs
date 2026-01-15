using CarRental.Domain.ValueObjects;
using CarRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarRental.Tests.ValueObjects
{
    public class CustomerIdTest
    {
        [Fact]
        public void Create_WithValidGuid_ShouldRetournCustomerId()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 
            var customerId = CustomerId.Create(guid);

            // Assert
            customerId.IdCustomer.Should().Be(guid);

        }

        [Fact]
        public void Create_WithEmptyGuid_ShouldThrowException()
        {
            // Arrange
            var guid = Guid.Empty;

            // Assert
            Assert.Throws<ValidationException>(() => CustomerId.Create(guid));

        }

        [Fact]
        public void TwoDifferentInstances_WithSameGuid_ShouldBeEqual()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act 
            var obj1 = CustomerId.Create(guid);
            var obj2 = CustomerId.Create(guid);
            // Assert

            obj1.Should().Be(obj2);

        }
    }
}
