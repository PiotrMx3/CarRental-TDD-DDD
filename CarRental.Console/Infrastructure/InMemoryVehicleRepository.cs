using CarRental.Domain.Abstractions.Repositories;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.App.Infrastructure
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new();


        public InMemoryVehicleRepository()
        {
            _vehicles.Add(new Vehicle(VehicleId.New(), "Toyota Yaris", VehicleClass.Basic));
            _vehicles.Add(new Vehicle(VehicleId.New(), "Ford Focus", VehicleClass.Standard));
            _vehicles.Add(new Vehicle(VehicleId.New(), "BMW X5", VehicleClass.Premium));
            _vehicles.Add(new Vehicle(VehicleId.New(), "Audi A6", VehicleClass.Premium));
        }



        public void Add(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public bool Exists(VehicleId id)
        {
            return _vehicles.Any(v => v.Id == id);
        }

        public Vehicle? GetById(VehicleId id)
        {
            return _vehicles.SingleOrDefault(v => v.Id == id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicles;
        }
    }
}
