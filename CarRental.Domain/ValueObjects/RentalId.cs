using CarRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.ValueObjects
{
    public record RentalId
    {
		private Guid _rentalId;

		public Guid IdRental
		{
			get { return _rentalId; }
		}

		private RentalId(Guid rentalId)
		{
			this._rentalId = rentalId;
		}


		public static RentalId Create(Guid rentalId)
		{
			if(rentalId == Guid.Empty) throw new ValidationException("Guid can not be empty !");
			return new RentalId(rentalId);
        }

		public static RentalId New()
		{
			Guid id = Guid.NewGuid();

			return new RentalId(id);
		}

	}
}
