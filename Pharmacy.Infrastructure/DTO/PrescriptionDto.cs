
using System;
using System.Collections.Generic;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.DTO
{
    public class PrescriptionDto
    {
        protected PrescriptionDto()
        {
            DateOfIssue = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }
        public DateTime DateOfIssue { get; set; }

        public IEnumerable<PrescriptionElementDto> Elements { get; set; }
    }
}