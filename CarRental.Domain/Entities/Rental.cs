using CarRental.Domain.ValueObjects;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Rental
    {

        private RentalId _rentalId;
        private ReservationId _reservationId;
        private VehicleId _vehicleId;
        private CustomerId _customerId;
        private DateRange _dateRange;
        private Money _priceToPay;
        private RentalStatus _status;

        private Rental(RentalId rentalId, ReservationId reservationId, VehicleId vehicleId, CustomerId customerId, DateRange dateRange, Money price)
        {
            _rentalId = rentalId;
            _reservationId = reservationId;
            _vehicleId = vehicleId;
            _customerId = customerId;
            _dateRange = dateRange;
            _priceToPay = price;
            _status = RentalStatus.Ongoing;
        }


        public static Rental Create(RentalId rentalId, ReservationId reservationId, VehicleId vehicleId, CustomerId customerId, DateRange dataRange, Money price)
        {
            return new Rental(rentalId, reservationId, vehicleId, customerId, dataRange, price);
        }

        public RentalStatus Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        public Money PriceToPay
        {
            get { return this._priceToPay; }
        }

        public DateRange DateRange
        {
            get { return this._dateRange; }
        }

        public CustomerId CustomerId
        {
            get { return this._customerId; }
        }

        public VehicleId VehicleId
        {
            get { return this._vehicleId; }
        }


        public ReservationId ReservationId
        {
            get { return this._reservationId; }
        }

        public RentalId RentalId
        {
            get { return this._rentalId; }
        }


        // Method's

        public bool IsReturned()
        {
            return Status == RentalStatus.Returned;
        }

    }
}
