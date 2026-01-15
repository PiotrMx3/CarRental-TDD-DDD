using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Exceptions;

namespace CarRental.Domain.ValueObjects
{
    public record FuelLevel
    {
		private float _levelOfFuel;

		public float LevelOfFuel
		{
			get { return this._levelOfFuel; }
		}

		private FuelLevel(float fuelLevel)
		{
			this._levelOfFuel = fuelLevel;
		}


		public static FuelLevel Create(float fuelLevel)
		{
			if (fuelLevel < 0 || fuelLevel > 1.0) throw new ValidationException("Fuel can not be lower then 0 or above 1");

			return new FuelLevel(fuelLevel);
		}

	}
}
