using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Policies
{
    public class StandardDepositPolicy : IDepositPolicy
    {
        public Money CalculateDeposit(VehicleClass vehicleClass)
        {
            decimal deposit = 0m;

            switch (vehicleClass)
            {
                case VehicleClass.Basic:
                    deposit = 500m;
                    break;
                case VehicleClass.Standard:
                    deposit = 1000m;
                    break;
                case VehicleClass.Premium:
                    deposit = 1500m;
                    break;
                default:
                    throw new DomainException($"Unknown vehicle class: {vehicleClass}");
            }

            return Money.Of(deposit);
        }
    }
}
