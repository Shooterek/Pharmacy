using System;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.DTO
{
    public class PrescriptionElementDto
    {
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public Guid MedicamentId { get; set; }
        public MedicamentDto Medicament { get; set; }

        public int Quantity { get; set; }
    }
}