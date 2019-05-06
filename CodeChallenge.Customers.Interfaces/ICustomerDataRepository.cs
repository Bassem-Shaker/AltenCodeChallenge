using CodeChallenge.Customers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Customers.Interfaces
{
    public interface ICustomerDataRepository
    {
        IEnumerable<Customer> GetAllCustomer();    
    }
}
