using CarRental.Domain.Enums;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Policies
{
    public interface IPricingStrategy
    {
        Money CalculateBasePrice(CarClass carClass, int days);
    }
}
