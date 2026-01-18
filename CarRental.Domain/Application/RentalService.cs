using CarRental.Domain.Abstractions;
using CarRental.Domain.Abstractions.Repositories;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using CarRental.Domain.Factories;
using CarRental.Domain.Services;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Application
{
    public class RentalService
    {
        private IVehicleRepository _vehicleRepository;
        private ICustomerRepository _customerRepository;
        private IRentalRepository _rentalRepository;
        private PricingService _pricingService;
        private PricingPoliciesFactory _policiesFactory;
        private AvailabilityService _availabilityService;
        private IClock _clock;

        public RentalService(
            IVehicleRepository vehicleRepository,
            ICustomerRepository customerRepository,
            IRentalRepository rentalRepository,
            PricingService pricingService,
            PricingPoliciesFactory policiesFactory,
            AvailabilityService availabilityService,
            IClock clock)
        {
            _vehicleRepository = vehicleRepository;
            _customerRepository = customerRepository;
            _rentalRepository = rentalRepository;
            _pricingService = pricingService;
            _policiesFactory = policiesFactory;
            _availabilityService = availabilityService;
            _clock = clock;
        }


        public Rental RentCar(VehicleId vehicleId, CustomerId customerId, DateRange period)
        {
            var vehicle = _vehicleRepository.GetById(vehicleId)
                ?? throw new DomainException($"Vehicle with ID {vehicleId.IdVehicle} not found.");

            var customer = _customerRepository.GetById(customerId)
                ?? throw new DomainException($"Customer with ID {customerId.IdCustomer} not found.");

            _availabilityService.ValidateAvailability(vehicleId, period);

            var strategy = _policiesFactory.CreatePricingStrategy(vehicle.CarClass);
            var depositPolicy = _policiesFactory.CreateDepositPolicy();
            var discountPolicy = _policiesFactory.CreateDiscountPolicy();

            var calculator = new PricingService(strategy, depositPolicy, discountPolicy);

            var priceBreakdown = calculator.CalculatePrice(vehicle.CarClass, period.Days);

            var rentalId = RentalId.New();
            var reservationId = ReservationId.New();

            var rental = Rental.Create(
                rentalId,
                reservationId,
                vehicleId,
                customerId,
                period,
                priceBreakdown.FinalAmount);

            _rentalRepository.Add(rental);

            return rental;
        }

    }
}
