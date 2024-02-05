using Boardcamp.Domain.Rentals.Repositories;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.Return
{
    public class ReturnRentalRequestHanlder : IRequestHandler<ReturnRentalRequest, Result>
    {
        private readonly IRentalRepository _rentalRepository;

        public ReturnRentalRequestHanlder(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Result> Handle(ReturnRentalRequest request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetByIdAsync(request.Id);
            if (rental == null) return Result.Failure("Aluguel não encontrado");

            var returnRentalResult = rental.Return();
            if (returnRentalResult.IsFailure) return Result.Failure(returnRentalResult.ErrorMessage!);

            return Result.Success();
        }
    }
}
