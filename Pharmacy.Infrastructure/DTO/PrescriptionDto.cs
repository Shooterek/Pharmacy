
using System;
using System.Collections.Generic;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.DTO
{
    public class PrescriptionDto
    {
        protected PrescriptionDto()
        {
            DateOfIssue = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfFinalization { get; set; }

        public string Provider { get; set; }
        public string NipOrRegonOfTheProvider { get; set; }

        public string NameOfThePatient { get; set; }
        public string SurnameOfThePatient { get; set; }
        public string AddressOfThePatient { get; set; }
        public string PeselNumberOfThePatient { get; set; }

        public string NameOfTheDoctor { get; set; }
        public string SurnameOfTheDoctor { get; set; }
        public string SpecializationOfTheDoctor { get; set; }
        public string LicenseNumberOfTheDoctor { get; set; }

        public IEnumerable<PrescriptionElementDto> Elements { get; set; }
    }
}