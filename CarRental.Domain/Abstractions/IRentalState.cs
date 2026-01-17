using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.States
{
    public interface IRentalState
    {
        void Return(Rental rental, DateTime returnDate);

        RentalStatus StatusName { get; }
    }
}
