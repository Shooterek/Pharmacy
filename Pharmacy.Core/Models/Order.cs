using System;
using System.Collections.Generic;

namespace Pharmacy.Core.Models
{
    public class Order
    {
        protected Order()
        {
        }

        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }
        public User Pharmacist { get; set; }
        public string Status { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfFinalization { get; set; }
        public IEnumerable<OrderElement> Elements { get; set; }
    }
}