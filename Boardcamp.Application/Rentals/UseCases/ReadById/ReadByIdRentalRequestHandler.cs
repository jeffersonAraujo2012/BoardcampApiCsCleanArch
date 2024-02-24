using Boardcamp.Domain.Rentals;
using Boardcamp.Domain.Rentals.Repositories;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.ReadById
{
    public class ReadByIdRentalRequestHandler : IRequestHandler<ReadByIdRentalRequest, Result<Rental>>
    {
        private readonly IRentalRepository _rentalRepository;

        public ReadByIdRentalRequestHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Result<Rental>> Handle(ReadByIdRentalRequest request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetByIdAsync(request.Id);
            if (rental == null) return Result.Failure<Rental>("O aluguél de id " + request.Id + " não foi encontrado");

            return Result.Success(rental);
        }
    }
}
