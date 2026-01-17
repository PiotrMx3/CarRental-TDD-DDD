using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using CarRental.Domain.ValueObjects;

namespace CarRental.Domain.Abstractions.Repositories
{
    public interface ICustomerRepository
    {
        Customer? GetById(CustomerId id);
        void Add(Customer customer);
    }
}
