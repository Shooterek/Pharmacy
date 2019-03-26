using System;

namespace Pharmacy.Core.Models
{
    public class PrescriptionElement
    {
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public Guid MedicamentId { get; set; }
        public Medicament Medicament { get; set; }

        public int Quantity { get; set; }
    }
}