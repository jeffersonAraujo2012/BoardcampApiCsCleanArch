using FluentValidation;

namespace Boardcamp.Application.Rentals.UseCases.Return
{
    public class ReturnRentalRequestValidator : AbstractValidator<ReturnRentalRequest>
    {
        public ReturnRentalRequestValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("O id do aluguel deve ser maior que 0");
        }
    }
}
