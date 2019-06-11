using System;

namespace Pharmacy.Core.Models
{
    public class PrescriptionElement
    {
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public string EanCode { get; set; }
        public Medicament Medicament { get; set; }

        public string Dosage { get; set; }
        public int Quantity { get; set; }
    }
}