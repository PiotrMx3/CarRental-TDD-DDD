using CarRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.ValueObjects
{
    public record ReservationId
    {
		private Guid _reservationId;

		public Guid IdReservation
		{
			get { return _reservationId; }
		}

		private ReservationId(Guid reservationId)
		{
			this._reservationId = reservationId;
		}

		public static ReservationId Create(Guid reservationId)
		{
			if (reservationId == Guid.Empty) throw new ValidationException("Guid can not be empty !");

			return new ReservationId(reservationId);
		}

		public static ReservationId New()
		{
			Guid reservationId = Guid.NewGuid();
			return new ReservationId(reservationId);

        }

	}
}
