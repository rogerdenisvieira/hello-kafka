
using Hello.Kafka.Domain.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello.Kafka.Customer.Producer.Controllers
{
    [Controller]
    [Route("/[controller]/[action]")]
    public class CustomerController : Controller
    {

        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpPost]
        public IActionResult Create(CustomerModel customer)
        {
            var result = this._customerService.CreateCustomer(customer);

            return Ok("Customer created successfully.");
        }
    }
}
