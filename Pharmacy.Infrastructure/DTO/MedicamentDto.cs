using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Infrastructure.DTO
{
    public class MedicamentDto
    {
        public string Name { get; set; }
        public string EanCode { get; set; }
        public bool IsRefunded { get; set; }
        public int PercentageOfRefund { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }
    }
}
