using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Enums;
using CarRental.Domain.ValueObjects;

namespace CarRental.Domain.Entities
{
	public class Vehicle
	{
		private VehicleId _id;
		private string _model;
		private CarClass _carClass;
		private CarStatus _status = CarStatus.Available;
		private bool _isMaintenance;


		public Vehicle(VehicleId id, string model, CarClass carClass)
		{
			this._id = id;
			this._model = model;
			this._carClass = carClass;
		}
		public bool IsMaintenance
		{
			get { return this._isMaintenance; }
			private set { _isMaintenance = value; }
		}

		public CarStatus Status
		{
			get { return this._status; }
			private set { this._status = value; }
		}


		public CarClass CarClass	
		{
			get { return this._carClass; }
		}


		public string Model
		{
			get { return this._model; }
		}


		public VehicleId Id
		{
			get { return this._id; }
		}


		// Methoden 

		public void FinishMaintenance()
		{
			IsMaintenance = false;
			Status = CarStatus.Available;
		}
		public void SetMaintenance()
		{
			IsMaintenance = true;
			
			Status = CarStatus.Maintenance;
		}

	}
}
