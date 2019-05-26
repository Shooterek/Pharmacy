using System;

namespace Pharmacy.Core.Models
{
    public class SaleElement
    {
        public Guid SaleId { get; set; }
        public Sale Sale { get; set; }

        public Guid MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
        
        public int Quantity { get; set; }
    }
}