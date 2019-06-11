using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Validators
{
    public class MedicamentValidator : AbstractValidator<MedicamentDto>
    {
        public MedicamentValidator()
        {
            RuleFor(m => m.EanCode).NotNull();
            RuleFor(m => m.EanCode).Length(13, 13);
            RuleFor(m => m.Quantity).NotNull();
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.IsRefunded).NotNull();
        }
    }
}
