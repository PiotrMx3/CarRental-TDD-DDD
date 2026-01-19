using CarRental.Domain.Abstractions.Repositories;
using CarRental.Domain.Entities;
using CarRental.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.App.Infrastructure
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {

        private readonly List<Customer> _customers = new();


        public InMemoryCustomerRepository()
        {
            _customers.Add(new Customer(
                CustomerId.New(),
                "Jan Jan",
                DriverLicenseNumber.Create("ABC1234567")
            ));
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer? GetById(CustomerId id)
        {
            return _customers.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }
    }
}
