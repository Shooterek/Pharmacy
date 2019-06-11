using System;
using System.Collections.Generic;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.DTO
{
    public class SaleDto
    {
        public SaleDto()
        {
            DateOfIssue = DateTime.UtcNow;
            Prescriptions = new List<PrescriptionDto>();
            MedicamentsSoldWithoutPrescription = new List<SaleElementDto>();
        }

        public Guid Id { get; set; }

        public Guid PharmacistId { get; set; }
        public UserDto Pharmacist { get; set; }
        public string DocumentName { get; set; }
        public DateTime DateOfIssue { get; set; }
        public ICollection<PrescriptionDto> Prescriptions { get; set; }
        public ICollection<SaleElementDto> MedicamentsSoldWithoutPrescription { get; set; }
    }
}