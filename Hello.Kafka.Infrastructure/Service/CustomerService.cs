using Hello.Kafka.Domain.Customer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hello.Kafka.Infrastructure.Service
{
    public class CustomerService : BaseKafkaService, ICustomerService
    {

        public CustomerService(IConfiguration configuration) : base (configuration)
        {
            
        }

        public bool CreateCustomer(CustomerModel customer)
        {
            base.ProduceAsync("customer", customer);
        }
    }
}
