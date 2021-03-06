﻿using System;

namespace Pharmacy.Infrastructure.DTO
{
    public class OrderElementDto
    {
        public Guid OrderId { get; set; }
        public OrderDto Order { get; set; }

        public string EanCode { get; set; }
        public MedicamentDto Medicament { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; } // unit purchase price
    }
}