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
    public class InMemoryReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> _reservations = new();

        public void Add(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public Reservation? GetById(ReservationId id)
        {
            return _reservations.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Reservation> GetOverlappingReservations(VehicleId vehicleId, DateRange range)
        {
            return _reservations.Where(r =>

                r.VehicleId == vehicleId &&

                r.Status != ReservationStatus.Cancelled &&

                r.Duration.Overlaps(range)
            
            );
        }
    }
}
