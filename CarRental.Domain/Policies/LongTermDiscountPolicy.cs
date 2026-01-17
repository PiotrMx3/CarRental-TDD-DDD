using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Policies
{
    public class LongTermDiscountPolicy : IDiscountPolicy
    {
        public Money CalculateDiscount(Money basePrice, int days)
        {
            if (days > 7)
            {
                var discountAmount = basePrice.Amount * 0.10m;
                return Money.Of(Math.Round(discountAmount, 2));
            }

            return Money.Of(0);
        }
    }
}
