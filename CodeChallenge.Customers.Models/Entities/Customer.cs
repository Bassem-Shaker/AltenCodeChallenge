using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Customers.Models.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public String Address { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
