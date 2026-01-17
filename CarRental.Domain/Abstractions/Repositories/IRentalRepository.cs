using CarRental.Domain.Entities;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Abstractions.Repositories
{
    public interface IRentalRepository
    {
        Rental? GetById(RentalId id);
        void Add(Rental rental);
        IEnumerable<Rental> GetActiveByVehicle(VehicleId id);
    }
}
