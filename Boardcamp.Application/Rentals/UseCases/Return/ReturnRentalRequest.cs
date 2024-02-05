using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.Return
{
    public class ReturnRentalRequest : IRequest<Result>
    {
        public long Id { get; set; }
    }
}
