using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Rentals.UseCases.Delete
{
    public class DeleteRentalRequestValidator : AbstractValidator<DeleteRentalRequest>
    {
        public DeleteRentalRequestValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("O id do aluguel deve ser maior que 0");
        }
    }
}
