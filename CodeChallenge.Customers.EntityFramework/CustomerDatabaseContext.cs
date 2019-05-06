using CodeChallenge.Customers.Models;
using CodeChallenge.Customers.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Customers.EntityFramework
{
    public class CustomerDatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) : base(options)
        {

        }
    }
}
