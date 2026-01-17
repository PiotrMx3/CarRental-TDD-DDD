using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Policies
{
    public class StandardPricingStrategy
    {
        public Money CalculateBasePrice(VehicleClass vehicleClass, int days)
        {
            if (days < 0) throw new ValidationException("Rental days must be greater than 0");

            decimal dailyRate = 0m;

            switch (vehicleClass)
            {
                case VehicleClass.Basic:
                    dailyRate = 100m;
                    break;
                case VehicleClass.Standard:
                    dailyRate = 200m;
                    break;
                case VehicleClass.Premium:
                    dailyRate = 300m;
                    break;
                default:
                    throw new DomainException($"No pricing strategy for {vehicleClass}");
            }

            return Money.Of(dailyRate * days);
        }
    }
}
