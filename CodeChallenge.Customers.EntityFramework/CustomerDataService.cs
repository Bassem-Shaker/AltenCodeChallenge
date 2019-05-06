using CodeChallenge.Customers.Interfaces;
using CodeChallenge.Customers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CodeChallenge.Customers.EntityFramework
{
    public class CustomerDataService : ICustomerDataRepository
    {
        private readonly CustomerDatabaseContext context;

        public CustomerDataService(CustomerDatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> GetAllCustomer()
        {
            IEnumerable<Customer> customers = context.Customers.AsEnumerable();
            return customers;
        }
    }

}
