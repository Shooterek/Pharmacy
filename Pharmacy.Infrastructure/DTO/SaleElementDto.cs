using System;
using Newtonsoft.Json;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.DTO
{
    public class SaleElementDto
    {
        public Guid SaleId { get; set; }
        [JsonIgnore]
        public SaleDto Sale { get; set; }

        public Guid MedicamentId { get; set; }
        public MedicamentDto Medicament { get; set; }

        public int Quantity { get; set; }
    }
}