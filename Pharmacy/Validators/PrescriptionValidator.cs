using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Validators
{
    public class PrescriptionValidator : AbstractValidator<PrescriptionDto>
    {
        public PrescriptionValidator()
        {
            RuleFor(p => p.Elements).NotEmpty();
            RuleFor(o => o.Elements).Custom(UniqueItems)
                .Custom((dtos, context) =>
                {
                    foreach (var prescriptionElementDto in dtos)
                    {
                        if (prescriptionElementDto.Quantity <= 0)
                        {
                            context.AddFailure("Quantity has to be higher than 0");
                        }
                    }
                });
        }

        private void UniqueItems(IEnumerable<PrescriptionElementDto> arg1, CustomContext arg2)
        {
            var set = new HashSet<Guid>();
            foreach (var t in arg1)
            {
                if (!set.Add(t.MedicamentId))
                {
                    arg2.AddFailure("The list cannot contain elements with the same medicamentId");
                }
            }
        }
    }
}
