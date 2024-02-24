﻿using FluentValidation;

namespace Boardcamp.Application.Customers.UseCases.ReadById
{
    public class ReadByIdRequestValidator : AbstractValidator<ReadByIdRentalRequest>
    {
        public ReadByIdRequestValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("O id do cliente deve ser maior que 0");
        }
    }
}
