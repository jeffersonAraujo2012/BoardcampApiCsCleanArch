using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Customers.UseCases.Upsert
{
    public class UpsertCustomerRequestValidator : AbstractValidator<UpsertCustomerRequest>
    {
        public UpsertCustomerRequestValidator()
        {
            When(p => p.Id is not null, () =>
            {
                RuleFor(p => p.Id)
                    .GreaterThan(0)
                    .WithMessage("O id deve ser maior que 0");
            });

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Você deve fornecer um nome");

            RuleFor(p => p.Cpf)
                .NotEmpty()
                .WithMessage("Você deve fornecer um cpf");

            RuleFor(p => p.Phone)
                .NotEmpty()
                .WithMessage("Você deve fornecer um telefone");

            RuleFor(p => p.Birthday)
                .LessThan(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("A data de nascimento deve ter ocorrido no passado.");
        }
    }
}