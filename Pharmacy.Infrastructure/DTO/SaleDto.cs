using System;
using System.Collections.Generic;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.DTO
{
    public class SaleDto
    {
        public Guid Id { get; set; }

        public Guid PharmacistId { get; set; }
        public UserDto Pharmacist { get; set; }

        public DateTime DateOfIssue { get; set; }

        public ICollection<PrescriptionDto> Prescriptions { get; set; }

        public ICollection<SaleElementDto> MedicamentsSoldWithoutPrescription { get; set; }
    }
}