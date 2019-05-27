using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Validators
{
    public class PrescriptionElementValidator : AbstractValidator<PrescriptionElementDto>
    {
        public PrescriptionElementValidator()
        {
            RuleFor(pe => pe.Quantity).GreaterThan(0);
            RuleFor(pe => pe.EanCode).NotEmpty();
        }
    }
}
