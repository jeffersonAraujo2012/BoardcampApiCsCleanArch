using Boardcamp.Application.Rentals.UseCases.ReadAll;
using Boardcamp.Domain.Rentals;
using Boardcamp.Domain.Rentals.Repositories;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.Read
{
    public class ReadAllRentalRequestHandler : IRequestHandler<ReadAllRentalsRequest, Result<IEnumerable<Rental>?>>
    {
        private readonly IRentalRepository _rentalRepository;

        public ReadAllRentalRequestHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Result<IEnumerable<Rental>?>> Handle(ReadAllRentalsRequest request, CancellationToken cancellationToken)
        {
            var rentals = await _rentalRepository.GetAllAsync();
            return Result.Success(rentals);
        }
    }
}
