using CarRental.Domain.Abstractions;
using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.States
{
    public class ReturnedState : IRentalState
    {
        public RentalStatus StatusName {
            get { return RentalStatus.Returned; }
        }

        public void Return(Rental rental, DateTime returnDate)
        {
            throw new DomainException("Rental is already returned.");
        }
    }
}
