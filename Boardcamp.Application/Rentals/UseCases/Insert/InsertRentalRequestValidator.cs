using FluentValidation;

namespace Boardcamp.Application.Rentals.UseCases.Insert
{
    public class InsertRentalRequestValidator : AbstractValidator<InsertRentalRequest>
    {
        public InsertRentalRequestValidator()
        {
            RuleFor(p => p.CustomerId)
                .GreaterThan(0)
                .WithMessage("O id do cliente deve ser maior que 0");

            RuleFor(p => p.GameId)
                .GreaterThan(0)
                .WithMessage("O id do jogo deve ser maior que 0");

            RuleFor(p => p.DaysRented)
                .GreaterThan(0)
                .WithMessage("O numero de dias alugados deve ser maior que 0");
        }
    }
}
