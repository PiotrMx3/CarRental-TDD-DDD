using CarRental.Domain.Enums;
using CarRental.Domain.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Factories
{
    public class PricingPoliciesFactory
    {
        public IPricingStrategy CreatePricingStrategy(VehicleClass vehicleClass)
        {
            switch (vehicleClass)
            {
                case VehicleClass.Premium:
                    return new PremiumPricingStrategy();
                default:
                    return new StandardPricingStrategy();
            }
        }

        public IDepositPolicy CreateDepositPolicy()
        {
            return new StandardDepositPolicy();
        }

        public IDiscountPolicy CreateDiscountPolicy()
        {
            return new LongTermDiscountPolicy();
        }
    }
}
