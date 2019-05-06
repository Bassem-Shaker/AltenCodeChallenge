using CodeChallenge.Customers.Controllers;
using CodeChallenge.Customers.Interfaces;
using CodeChallenge.Customers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace CodeChallenge.Customers.UnitTest
{
    public class CustomerControllerTest
    {
        ICustomerDataRepository customerDataRepository;
        CustomerController customerController;

        public CustomerControllerTest()
        {
            customerDataRepository = new CustomerDataRepositoryFake();
            customerController = new CustomerController(customerDataRepository);
        }

        [Fact]
        public void Getall_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = customerController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = customerController.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }

}
