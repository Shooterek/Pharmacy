using System;
using System.Collections.Generic;

namespace Pharmacy.Core.Models
{
    public class Medicament
    {
        public string Name { get; set; }
        public string EanCode { get; set; }
        public bool IsRefunded { get; set; }
        public int PercentageOfRefund { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public string Comment { get; set; }

        public IEnumerable<PrescriptionElement> PrescriptionElements { get; set; }
        public IEnumerable<OrderElement> OrderElements { get; set; }

        public IEnumerable<SaleElement> SaleElements { get; set; }
    }
}