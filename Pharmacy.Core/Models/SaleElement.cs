using System;

namespace Pharmacy.Core.Models
{
    public class SaleElement
    {
        public Guid SaleId { get; set; }
        public Sale Sale { get; set; }

        public string EanCode { get; set; }
        public Medicament Medicament { get; set; }
        
        public int Quantity { get; set; }
    }
}