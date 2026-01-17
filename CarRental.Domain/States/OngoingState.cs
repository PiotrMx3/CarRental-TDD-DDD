using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.States
{
    public class OngoingState : IRentalState
    {
        public RentalStatus StatusName
        {
            get { return RentalStatus.Ongoing; }
        }

        public void Return(Rental rental, DateTime returnDate)
        {
            rental.SetReturnDate(returnDate);

            rental.ChangeState(new ReturnedState());
        }


    }
}
