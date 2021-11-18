using System;
using System.Collections.Generic;
using System.Text;

namespace Hello.Kafka.Domain.Customer
{
    public interface ICustomerService
    {
       bool CreateCustomer(CustomerModel customer);
    }
}
