using System;
using System.Collections.Generic;
using System.Text;

namespace Hello.Kafka.Domain.Customer
{
    public class CustomerModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;

        private DateTime _customerSince;


        public DateTime CustomerSince
        {
            get => _customerSince != null ? _customerSince : DateTime.Now;
            set { _customerSince = value; }
        }
    }
}
