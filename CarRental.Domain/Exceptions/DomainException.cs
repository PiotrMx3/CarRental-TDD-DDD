using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string? message) : base(message)
        {
        }
    }

    public class CarAlreadyBookedException : DomainException
    {
        public CarAlreadyBookedException(string? message) : base(message)
        {
        }
    }

    public class InvalidStateTransitionException : DomainException
    {
        public InvalidStateTransitionException(string? message) : base(message)
        {
        }
    }

    public class ValidationException : DomainException
    {
        public ValidationException(string? message) : base(message)
        {
        }
    }

    public class InvalidDriverLicenseException : DomainException
    {
        public InvalidDriverLicenseException(string? message) : base(message)
        {
        }
    }

    public class InvalidMoneyAmountException : DomainException
    {
        public InvalidMoneyAmountException(decimal amount) : base($"Amount can not be lower then 0: {amount}")
        {

        }
    }
}
