using Boardcamp.Domain.Rentals;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.ReadById
{
    public class ReadByIdRentalRequest : IRequest<Result<Rental>>
    {
        public long Id { get; set; }
    }
}
