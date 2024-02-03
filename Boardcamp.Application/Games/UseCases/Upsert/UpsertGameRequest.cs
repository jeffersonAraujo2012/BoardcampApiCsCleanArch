using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Games.UseCases.Upsert
{
    public class UpsertGameRequest : IRequest<Result>
    {
        public long? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int Stock { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
