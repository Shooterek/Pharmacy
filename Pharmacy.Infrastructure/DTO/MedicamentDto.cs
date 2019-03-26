using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Infrastructure.DTO
{
    public class MedicamentDto
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string EanCode { get; set; }
        public bool IsRefunded { get; set; }
        public int Quantity { get; set; }
    }
}
