using CarRental.Domain.Enums;
using CarRental.Domain.States;
using CarRental.Domain.ValueObjects;
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
        private IRentalState _state;
        private DateTime? _returnedAt;



        private Rental(RentalId rentalId, ReservationId reservationId, VehicleId vehicleId, CustomerId customerId, DateRange dateRange, Money price)
        {
            _rentalId = rentalId;
            _reservationId = reservationId;
            _vehicleId = vehicleId;
            _customerId = customerId;
            _dateRange = dateRange;
            _priceToPay = price;
            _state = new OngoingState();
        }


        public static Rental Create(RentalId rentalId, ReservationId reservationId, VehicleId vehicleId, CustomerId customerId, DateRange dataRange, Money price)
        {
            return new Rental(rentalId, reservationId, vehicleId, customerId, dataRange, price);
        }

        public DateTime? ReturnedAt
        {
            get { return _returnedAt; }
        }
        public RentalStatus Status
        {
            get { return _state.StatusName; }
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
        public bool IsReturned
        {
            get { return Status == RentalStatus.Returned; }
        }


        // Method's


        public void Return(DateTime returnDate)
        {
            _state.Return(this, returnDate);
        }


        internal void ChangeState(IRentalState newState)
        {
            _state = newState;
        }

        internal void SetReturnDate(DateTime returnDate)
        {
            _returnedAt = returnDate;
        }

    }
}
