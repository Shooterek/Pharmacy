using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Models
{
    public class OrderElement
    {
        public Guid OrderId{ get; set; }
        public Order Order { get; set; }

        public Guid MedicamentId { get; set; }
        public Medicament Medicament { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; } // unit purchase price
    }
}
