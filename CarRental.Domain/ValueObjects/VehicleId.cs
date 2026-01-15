using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Exceptions;

namespace CarRental.Domain.ValueObjects
{
    public record VehicleId
    {
		private Guid _vehicleId;

		public Guid IdVehicle
		{
			get { return this._vehicleId; }
		}

		private VehicleId (Guid vehicleId)
		{
			this._vehicleId = vehicleId;
		}

		public static VehicleId Create(Guid vehicleId)
		{
			if (vehicleId == Guid.Empty) throw new ValidationException("Guid can not be empty !");

			return new VehicleId(vehicleId);
		}

		public static VehicleId New()
		{
			Guid newGuid = Guid.NewGuid();
			return new VehicleId(newGuid);
		}

	}
}
