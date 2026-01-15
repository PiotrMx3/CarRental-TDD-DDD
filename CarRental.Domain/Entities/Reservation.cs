using CarRental.Domain.Abstractions;
using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Reservation
    {
        private ReservationId _id;
        private DateRange _duration;
        private VehicleId _vehicleId;
        private CustomerId _customerId;
        private ReservationStatus _status;
        private DateTime _createdAt;

        private Reservation(
        ReservationId id,
        DateRange duration,
        VehicleId vehicleId,
        CustomerId customerId,
        DateTime createdAt)
        {
            _id = id;
            _duration = duration;
            _vehicleId = vehicleId;
            _customerId = customerId;
            _status = ReservationStatus.Pending;
            _createdAt = createdAt;
        }

        public static Reservation Create(
        ReservationId id,
        DateRange duration,
        VehicleId vehicleId,
        CustomerId customerId,
        IClock clock)

        {
            if (duration.Start < clock.Now()) throw new ValidationException("Reservation start date cannot be in the past.");
            return new Reservation(id, duration, vehicleId, customerId, clock.Now());
        }

        public ReservationId Id
        {
            get { return _id; }
        }

        public DateRange Duration
        {
            get { return _duration; }
        }

        public VehicleId VehicleId
        {
            get { return _vehicleId; }
        }

        public CustomerId CustomerId
        {
            get { return _customerId; }
        }

        public ReservationStatus Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }


    }
}
