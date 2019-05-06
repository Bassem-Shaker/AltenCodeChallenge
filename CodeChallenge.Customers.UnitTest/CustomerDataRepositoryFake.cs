using CodeChallenge.Customers.Interfaces;
using CodeChallenge.Customers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Customers.UnitTest
{
    public class CustomerDataRepositoryFake : ICustomerDataRepository
    {
        private readonly IEnumerable<Customer> customers;

        public CustomerDataRepositoryFake()
        {
            customers = new List<Customer>()
            {
               new Customer(){ ID=1,Name="Kalles Grustransporter AB",Address="Cementvägen 8, 111 11 Södertälje"},
               new Customer(){ ID=2,Name="Johans Bulk AB",Address=""},
               new Customer(){ ID=3,Name="",Address=""}
            };
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return customers;
        }
    }

}
