using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Abstractions;
using CarRental.Domain.Abstractions.Repositories;
using CarRental.Domain.Application;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.Factories;
using CarRental.Domain.Policies;
using CarRental.Domain.Services;
using CarRental.Domain.ValueObjects;
using FluentAssertions;
using Moq;
using Xunit;


namespace CarRental.Tests.Application
{
    public class RentalServiceTests
    {
        private Mock<IVehicleRepository> _vehicleRepoMock = new();
        private Mock<ICustomerRepository> _customerRepoMock = new();
        private Mock<IRentalRepository> _rentalRepoMock = new();
        private Mock<IReservationRepository> _reservationRepoMock = new();
        private Mock<IClock> _cloclMock = new();

        private PricingService _pricingService;
        private AvailabilityService _availabilityService;
        private PricingPoliciesFactory _policiesFactory;


        // SUT 
        private RentalService _rentalService;


        public RentalServiceTests()
        {
            _policiesFactory = new PricingPoliciesFactory();

            var pricingStrategyMock = new Mock<IPricingStrategy>();
            pricingStrategyMock
                .Setup(x => x.CalculateBasePrice(It.IsAny<VehicleClass>(), It.IsAny<int>()))
                .Returns(Money.Of(500));

            var depositPolicyMock = new Mock<IDepositPolicy>();
            depositPolicyMock.Setup(x => x.CalculateDeposit(It.IsAny<VehicleClass>()))
            .Returns(Money.Of(100));

            var discountPolicyMock = new Mock<IDiscountPolicy>();
            discountPolicyMock
                .Setup(x => x.CalculateDiscount(It.IsAny<Money>(), It.IsAny<int>()))
                .Returns(Money.Of(0));


            _pricingService = new PricingService(pricingStrategyMock.Object, depositPolicyMock.Object, discountPolicyMock.Object);
            _availabilityService = new AvailabilityService(_reservationRepoMock.Object);


            _rentalService = new RentalService(
                _vehicleRepoMock.Object,
                _customerRepoMock.Object,
                _rentalRepoMock.Object,
                _pricingService,
                _policiesFactory,
                _availabilityService,
                _cloclMock.Object
                );


        }
        [Fact]
        public void RentCar_ShouldCreateAndSaveRental_WhenAllChecksPass()
        {
            // Arrange
            var vehicleId = VehicleId.New();
            var customerId = CustomerId.New();
            var start = new DateTime(2024, 1, 1);
            var end = new DateTime(2024, 1, 5);
            var dateRange = DateRange.Create(start, end);


            // 1. Setup Car
            var vehicle = new Vehicle(vehicleId, "Ford Focus", VehicleClass.Standard);
            _vehicleRepoMock
                .Setup(x => x.GetById(vehicleId))
                .Returns(vehicle);

            // 2. Setup Customer
            var customer = new Customer(customerId, "Jan Jan", DriverLicenseNumber.Create("1234567890"));
            _customerRepoMock
                .Setup(x => x.GetById(customerId))
                .Returns(customer);


            // 2. Setup Available
            _reservationRepoMock
                .Setup(x => x.GetOverlappingReservations(vehicleId, dateRange))
                .Returns(new List<Reservation>());


            // Act
            var rental = _rentalService.RentCar(vehicleId, customerId, dateRange);


            // Assert
            _rentalRepoMock.Verify(x => x.Add(It.IsAny<Rental>()), Times.Once);

            rental.Should().NotBeNull();
            rental.PriceToPay.Amount.Should().Be(800);
            rental.Status.Should().Be(RentalStatus.Ongoing);
        }

       
    }
}
