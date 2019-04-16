using System;
using System.Collections.Generic;

namespace Pharmacy.Infrastructure.DTO
{
    public class OrderDto
    {
        protected OrderDto()
        {
            DateOfIssue = DateTime.UtcNow;
            Elements = new List<OrderElementDto>();
        }

        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }
        public UserDto Pharmacist { get; set; }
        public string Status { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfFinalization { get; set; }
        public ICollection<OrderElementDto> Elements { get; set; }
    }
}