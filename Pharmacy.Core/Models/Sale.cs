using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Models
{
    public class Sale
    {
        public Guid Id { get; set; }

        public Guid PharmacistId { get; set; }
        public User Pharmacist { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string DocumentName { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public ICollection<SaleElement> MedicamentsSoldWithoutPrescription { get; set; }
    }
}
