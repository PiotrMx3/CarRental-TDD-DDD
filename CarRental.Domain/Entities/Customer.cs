using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.ValueObjects;

namespace CarRental.Domain.Entities
{
    public class Customer
    {
		private CustomerId _id;
		private string _name;
		private DriverLicenseNumber _driverLicense;

		public Customer(CustomerId id, string name, DriverLicenseNumber driverLicenseNumber)
		{
			this._id = id;
			this._name = name;
			this._driverLicense = driverLicenseNumber;
		}

		public DriverLicenseNumber DriverLicense
		{
			get { return this._driverLicense; }
		}


		public string Name
		{
			get { return this._name; }
		}


		public CustomerId Id
		{
			get { return this._id; }
		}


	}
}
