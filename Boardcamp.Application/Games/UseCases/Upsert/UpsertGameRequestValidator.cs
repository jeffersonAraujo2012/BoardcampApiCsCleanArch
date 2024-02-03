using FluentValidation;

namespace Boardcamp.Application.Games.UseCases.Upsert
{
    public class UpsertGameRequestValidator : AbstractValidator<UpsertGameRequest>
    {
        public UpsertGameRequestValidator()
        {
            When(p => p.Id != null, () =>
            {
                RuleFor(p => p.Id)
                    .GreaterThan(0)
                    .WithMessage("O id deve ser maior que 0");
            });

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Você deve fornecer um nome para o jogo");

            RuleFor(p => p.PricePerDay)
                .GreaterThan(0)
                .WithMessage("Você deve fornecer um preço por dia maior que 0");

            RuleFor(p => p.Stock)
                .GreaterThan(0)
                .WithMessage("Você não pode criar um jogo com estoque igual ou menor que 0");

            RuleFor(p => p.Image)
                .NotEmpty()
                .WithMessage("Você deve fornecer uma imagem para o jogo");
        }
    }
}
