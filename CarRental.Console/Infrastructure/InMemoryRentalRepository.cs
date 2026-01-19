using CarRental.Domain.Abstractions.Repositories;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.App.Infrastructure
{
    public class InMemoryRentalRepository : IRentalRepository
    {

        private readonly List<Rental> _rentals = new();



        public void Add(Rental rental)
        {
            _rentals.Add(rental);
        }

        public IEnumerable<Rental> GetActiveByVehicle(VehicleId id)
        {
            return _rentals.Where(r => r.VehicleId == id && r.Status == RentalStatus.Ongoing);
        }

        public Rental? GetById(RentalId id)
        {
            return _rentals.SingleOrDefault(r => r.RentalId == id);
        }

        public IEnumerable<Rental> GetAll()
        {
            return _rentals;
        }
    }
}
