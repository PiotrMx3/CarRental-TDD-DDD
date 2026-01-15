using CarRental.Domain.ValueObjects;
using CarRental.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.Entities
{
    public class CustomerTest
    {
        [Fact]

        public void Create_ShouldInitializeCustomer_WithCorrectValues()
        {
            // Arrange 
            string driverLicenseNumber = "2324534596";
            CustomerId id = CustomerId.New();
            string name = "Crazy_Frog";
            DriverLicenseNumber license = DriverLicenseNumber.Create(driverLicenseNumber);

            // Act
            Customer customer = new Customer(id, name, license);

            // Assert 
            customer.Id.Should().Be(id);
            customer.Name.Should().Be(name);
            customer.DriverLicense.Should().Be(license);

        }
    }
}
