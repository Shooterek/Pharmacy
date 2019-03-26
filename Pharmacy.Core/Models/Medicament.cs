using System;
using System.Collections.Generic;

namespace Pharmacy.Core.Models
{
    public class Medicament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EanCode { get; set; }
        public bool IsRefunded { get; set; }
        public int Quantity { get; set; }

        public IEnumerable<PrescriptionElement> PrescriptionElements { get; set; }
    }
}