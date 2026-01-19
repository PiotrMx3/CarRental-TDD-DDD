using CarRental.App.Infrastructure;
using CarRental.Domain.Application;
using CarRental.Domain.Enums;
using CarRental.Domain.Factories;
using CarRental.Domain.Services;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.App
{
    internal class Program
    {

        private static RentalService _rentalService;

        private static InMemoryVehicleRepository _vehicleRepo;
        private static InMemoryCustomerRepository _customerRepo;
        private static InMemoryRentalRepository _rentalRepo;

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Car Rental System...");

            _vehicleRepo = new InMemoryVehicleRepository();
            _customerRepo = new InMemoryCustomerRepository();
            var reservationRepo = new InMemoryReservationRepository();

            _rentalRepo = new InMemoryRentalRepository();

            var clock = new SystemClock();

            var availabilityService = new AvailabilityService(reservationRepo);
            var policiesFactory = new PricingPoliciesFactory();

            var defaultPricingService = new PricingService(
                policiesFactory.CreatePricingStrategy(VehicleClass.Standard),
                policiesFactory.CreateDepositPolicy(),
                policiesFactory.CreateDiscountPolicy()
            );

            _rentalService = new RentalService(
                _vehicleRepo,
                _customerRepo,
                _rentalRepo,
                defaultPricingService,
                policiesFactory,
                availabilityService,
                clock
            );

            Console.WriteLine("System Ready!\n");

            while (true)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("CAR RENTAL SYSTEM - MAIN MENU");
                Console.WriteLine("=================================");
                Console.WriteLine("1. List Available Cars");
                Console.WriteLine("2. List Customers");
                Console.WriteLine("3. RENT A CAR (Create Rental)");
                Console.WriteLine("4. Show Active Rentals");
                Console.WriteLine("5. Exit");
                Console.Write("Select option: ");

                var input = Console.ReadLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            ShowVehicles();
                            break;
                        case "2":
                            ShowCustomers();
                            break;
                        case "3":
                            HandleRentCar();
                            break;
                        case "4":
                            ShowActiveRentals();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            static void ShowVehicles()
            {
                Console.WriteLine("\n--- VEHICLES ---");
                foreach (var v in _vehicleRepo.GetAll())
                {
                    Console.WriteLine($"ID: {v.Id.IdVehicle} | {v.Model} ({v.CarClass}) | Status: {v.Status}");
                }
            }

            static void ShowCustomers()
            {
                Console.WriteLine("\n--- CUSTOMERS ---");
                foreach (var c in _customerRepo.GetAll())
                {
                    Console.WriteLine($"ID: {c.Id.IdCustomer} | Name: {c.Name}");
                }
            }

            static void ShowActiveRentals()
            {
                Console.WriteLine("\n--- ACTIVE RENTALS ---");
                var rentals = _rentalRepo.GetAll();
                if (!rentals.Any())
                {
                    Console.WriteLine("No active rentals.");
                    return;
                }

                foreach (var r in rentals)
                {
                    Console.WriteLine($"Rental ID: {r.RentalId.IdRental}");
                    Console.WriteLine($"   Car ID: {r.VehicleId.IdVehicle}");
                    Console.WriteLine($"   Customer: {r.CustomerId.IdCustomer}");
                    Console.WriteLine($"   Period: {r.DateRange.Start:yyyy-MM-dd} to {r.DateRange.End:yyyy-MM-dd} ({r.DateRange.Days} days)");
                    Console.WriteLine($"   PRICE TO PAY: {r.PriceToPay.Amount} (Status: {r.Status})");
                    Console.WriteLine("------------------------------------------------");
                }
            }

            static void HandleRentCar()
            {
                Console.WriteLine("\n--- NEW RENTAL ---");

                ShowVehicles();
                Console.Write("Enter Vehicle ID (copy-paste GUID): ");
                var vIdString = Console.ReadLine();
                var vehicleId = VehicleId.Create(Guid.Parse(vIdString));

                ShowCustomers();
                Console.Write("Enter Customer ID (copy-paste GUID): ");
                var cIdString = Console.ReadLine();
                var customerId = CustomerId.Create(Guid.Parse(cIdString));

                Console.Write("Enter Start Date (yyyy-MM-dd): ");
                var start = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Days (duration): ");
                var days = int.Parse(Console.ReadLine());
                var end = start.AddDays(days);

                var range = DateRange.Create(start, end);

                Console.WriteLine("Processing rental...");

                var rental = _rentalService.RentCar(vehicleId, customerId, range);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("SUCCESS! Car rented.");
                Console.WriteLine($"Total Price: {rental.PriceToPay.Amount}");
                Console.ResetColor();
            }
        }

    }
   
}
