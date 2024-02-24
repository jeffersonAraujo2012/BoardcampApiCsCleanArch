using Boardcamp.Application.HandlersBase;
using Boardcamp.Domain;
using Boardcamp.Domain.Rentals.Repositories;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.Delete
{
    public class DeleteRentalRequestHandler : HandlerBase, IRequestHandler<DeleteRentalRequest, Result>
    {
        private readonly IRentalRepository _rentalRepository;

        public DeleteRentalRequestHandler(IUnitOfWork unitOfWork, IRentalRepository rentalRepository) : base(unitOfWork)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<Result> Handle(DeleteRentalRequest request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetByIdAsync(request.Id);

            if (rental is null) return Result.Failure("O aluguel a ser deletado não existe");
            if (rental.ReturnDate is null) return Result.Failure("Você não pode deletar um aluguel que não foi finalizado");

            var deleteResult = await _rentalRepository.DeleteAsync(rental);

            if (deleteResult.IsFailure)
            {
                return deleteResult;
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }
    }
}
