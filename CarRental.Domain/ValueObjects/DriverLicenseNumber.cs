using CarRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.ValueObjects
{
    public record DriverLicenseNumber
    {
		private string _driverLicenseNum;

		public string DriverLicenseNum
		{
			get { return this._driverLicenseNum; }
		}

		private DriverLicenseNumber(string driverLicenseNumber)
		{
			this._driverLicenseNum = driverLicenseNumber;
		}


		public static DriverLicenseNumber Create(string driverLicenseNumber)
		{
			if (string.IsNullOrWhiteSpace(driverLicenseNumber) || driverLicenseNumber.Length < 10) throw new InvalidDriverLicenseException("Driver License Number should be atleast 10 charachters long and can not be empy");

			return new DriverLicenseNumber(driverLicenseNumber);
		}

	}
}
