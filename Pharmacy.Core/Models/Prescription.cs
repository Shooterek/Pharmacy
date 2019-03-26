using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Models
{
    public class Prescription
    {
        protected Prescription()
        {
        }

        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }

        public DateTime DateOfIssue { get; set; }

        public IEnumerable<PrescriptionElement> Elements { get; set; }
    }
}