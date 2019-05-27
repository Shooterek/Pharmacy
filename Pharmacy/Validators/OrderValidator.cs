using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Validators
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(o => o.Elements).NotEmpty();
            RuleFor(o => o.Elements).Custom(UniqueItems)
                .Custom((dtos, context) =>
                {
                    foreach (var orderElementDto in dtos)
                    {
                        if (orderElementDto.Quantity <= 0)
                        {
                            context.AddFailure("Quantity has to be higher than 0");
                        }
                    }
                });
        }

        private void UniqueItems(IEnumerable<OrderElementDto> arg1, CustomContext arg2)
        {
            var set = new HashSet<string>();
            foreach (var t in arg1)
            {
                if (!set.Add(t.EanCode))
                {
                    arg2.AddFailure("The list cannot contain elements with the same ean code");
                }
            }
        }
    }
}
