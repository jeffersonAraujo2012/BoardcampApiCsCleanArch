using Boardcamp.Domain.Rentals;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.ReadAll
{
    public class ReadAllRentalsRequest : IRequest<Result<IEnumerable<Rental>?>>
    {
    }
}