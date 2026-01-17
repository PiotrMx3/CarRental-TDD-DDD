using CarRental.Domain.Entities;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Abstractions.Repositories
{
    public interface IReservationRepository
    {
        Reservation? GetById(ReservationId id);
        IEnumerable<Reservation> GetOverlappingReservations(VehicleId vehicleId, DateRange range);
        void Add(Reservation reservation);
    }
}
