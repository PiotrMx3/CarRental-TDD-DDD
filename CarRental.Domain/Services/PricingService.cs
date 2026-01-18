using CarRental.Domain.Enums;
using CarRental.Domain.Policies;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Services
{
    public class PricingService
    {
        private IPricingStrategy _pricingStrategy;
        private IDepositPolicy _depositPolicy;
        private IDiscountPolicy _discountPolicy;

        public PricingService(IPricingStrategy pricingStrategy, IDepositPolicy depositPolicy, IDiscountPolicy discountPolicy)
        {
            _pricingStrategy = pricingStrategy;
            _depositPolicy = depositPolicy;
            _discountPolicy = discountPolicy;
        }



        public PriceBreakdown CalculatePrice(VehicleClass vehicleClass, int days)
        {
            var basePrice = _pricingStrategy.CalculateBasePrice(vehicleClass, days);

            var deposit = _depositPolicy.CalculateDeposit(vehicleClass);

            var discount = _discountPolicy.CalculateDiscount(basePrice, days);

            return new PriceBreakdown
            {
                BasePrice = basePrice,
                Deposit = deposit,
                Discount = discount,
                Penalty = Money.Of(0)
            };
        }



    }
}
