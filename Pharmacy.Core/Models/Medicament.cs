using System;

namespace Pharmacy.Core.Models
{
    public class Medicament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EanCode { get; set; }
        public bool IsRefunded { get; set; }
    }
}