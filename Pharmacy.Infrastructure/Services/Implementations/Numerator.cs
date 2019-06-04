using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Infrastructure.Services.Implementations
{
    public class Numerator : INumerator
    {
        private int _orderNumber = 1;
        private int _saleNumber = 1;
        private int _prescriptionNumber = 1;

        public void SetName(OrderDto order)
        {
            var name = new StringBuilder();
            name.Append("Z/")
                .Append(DateTime.UtcNow.Year)
                .Append("/")
                .Append(_orderNumber);
            _orderNumber++;

            order.DocumentName = name.ToString();
        }

        public void SetName(SaleDto sale)
        {
            var name = new StringBuilder();
            name.Append("S/")
                .Append(DateTime.UtcNow.Year)
                .Append("/")
                .Append(_saleNumber);
            _saleNumber++;

            sale.DocumentName = name.ToString();
        }

        public void SetName(PrescriptionDto prescription)
        {
            var name = new StringBuilder();
            name.Append("R/")
                .Append(DateTime.UtcNow.Year)
                .Append("/")
                .Append(_prescriptionNumber);
            _prescriptionNumber++;

            prescription.DocumentName = name.ToString();
        }
    }
}
