using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Validators
{
    public class OrderElementValidator : AbstractValidator<OrderElementDto>
    {
        public OrderElementValidator()
        {
            RuleFor(oe => oe.Quantity).GreaterThan(0);
            RuleFor(oe => oe.MedicamentId).NotEmpty();
        }
    }
}
