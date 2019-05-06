using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Customers.Interfaces;
using CodeChallenge.Customers.Models.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Customers.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDataRepository customerDataService;

        public CustomerController(ICustomerDataRepository customerDataService)
        {
            this.customerDataService = customerDataService;
        }
        // GET: api/Customer
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            IEnumerable<Customer> customers= customerDataService.GetAllCustomer();
            return Ok(customers);
        }
    }
}