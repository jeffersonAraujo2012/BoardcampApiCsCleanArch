using FluentValidation;

namespace Boardcamp.Application.Rentals.UseCases.ReadById
{
    public class ReadByIdRequestValidator : AbstractValidator<ReadByIdRentalRequest>
    {
        public ReadByIdRequestValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("O id do aluguél deve ser maior que 0");
        }
    }
}
