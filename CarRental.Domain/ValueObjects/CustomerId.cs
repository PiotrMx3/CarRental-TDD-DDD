using CarRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.ValueObjects
{
    public record CustomerId
    {
        private Guid _customerId;

        public Guid IdCustomer
        {
            get { return this._customerId; }
        }

        private CustomerId(Guid customerId)
        {
            this._customerId = customerId;
        }

        public static CustomerId Create(Guid customerId)
        {
            if (customerId == Guid.Empty) throw new ValidationException("Guid can not be empty !");

            return new CustomerId(customerId);
        }

        public static CustomerId New()
        {
            Guid customerId = Guid.NewGuid();
            return new CustomerId(customerId);
        }
    }
}
