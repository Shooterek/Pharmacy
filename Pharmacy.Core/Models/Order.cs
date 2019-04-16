using System;
using System.Collections.Generic;

namespace Pharmacy.Core.Models
{
    public class Order
    {
        protected Order()
        {
            Elements = new List<OrderElement>();
        }

        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }
        public User Pharmacist { get; set; }
        public string Status { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfFinalization { get; set; }
        public ICollection<OrderElement> Elements { get; set; }
    }
}