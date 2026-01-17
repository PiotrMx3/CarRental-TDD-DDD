using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.ValueObjects
{
    public record PriceBreakdown
    {
        private Money _basePrice;
        private Money _discount;
        private Money _deposit;
        private Money _penalty;


        public PriceBreakdown()
        {
            this._basePrice = Money.Of(0);
            this._discount = Money.Of(0);
            this._deposit = Money.Of(0);
            this._penalty = Money.Of(0);
        }

        public Money FinalAmount
        {
            get
            {
                return (BasePrice - Discount) + Penalty;
            }
        }

        public Money Penalty
        {
            get { return this._penalty; }
        }


        public Money Deposit
        {
            get { return this._deposit; }
        }


        public Money Discount
        {
            get { return this._discount; }
        }


        public Money BasePrice
        {
            get { return this._basePrice; }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Base Price: {BasePrice.Amount}");
            if (Discount.Amount > 0) sb.AppendLine($"Discount: -{Discount.Amount}");
            if (Penalty.Amount > 0) sb.AppendLine($"Penalty: +{Penalty.Amount}");
            sb.AppendLine("----------------");
            sb.AppendLine($"TOTAL: {FinalAmount.Amount}");
            sb.AppendLine($"Deposit (Refundable): {Deposit.Amount}");
            return sb.ToString();
        }

    }
}
