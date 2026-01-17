using CarRental.Domain.Abstractions.Repositories;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Services
{
    public class AvailabilityService
    {
        private IReservationRepository _reservationRepository;

        public IReservationRepository ReservationRepository
        {
            get { return this._reservationRepository; }
        }

        public AvailabilityService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public void ValidateAvailability(VehicleId vehicleId, DateRange range)
        {
            var conflicts = _reservationRepository.GetOverlappingReservations(vehicleId, range);

            if (conflicts.Any())
            {
                throw new CarAlreadyBookedException($"Vehicle {vehicleId.IdVehicle} is already booked in this period.");
            }
        }
    }
}
