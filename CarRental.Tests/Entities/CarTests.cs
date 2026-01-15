using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.ValueObjects;
using CarRental.Domain.Enums;

namespace CarRental.Tests.Entities
{
    public class CarTests
    {
        [Fact]
        public void Create_ShouldInitializeCar_WithCorrectValues_AndAvailableStatus()
        {
            // Arrange 
            var id = VehicleId.New();
            var model = "Toyota Corolla";
            var carClass = CarClass.Standard;

            // Act
            var car = new CarClass(id, model, carClass);

            // Assert

            car.Id.Should().Be(id);
            car.Model.Should().Be(model);
            car.CarClass.Should().Be(carClass);

            car.Status.Should().Be(CarStatus.Available);
            
        }
    }
}
