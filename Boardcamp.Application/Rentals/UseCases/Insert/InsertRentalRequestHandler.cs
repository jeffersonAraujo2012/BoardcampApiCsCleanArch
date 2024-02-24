using Boardcamp.Application.HandlersBase;
using Boardcamp.Domain;
using Boardcamp.Domain.Customers.Repositories;
using Boardcamp.Domain.Games.Repositories;
using Boardcamp.Domain.Rentals;
using Boardcamp.Domain.Rentals.Repositories;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.Insert
{
    public class InsertRentalRequestHandler : HandlerBase, IRequestHandler<InsertRentalRequest, Result>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IGameRepository _gameRepository;

        public InsertRentalRequestHandler(IUnitOfWork unitOfWork, IRentalRepository rentalRepository, ICustomerRepository customerRepository, IGameRepository gameRepository) : base(unitOfWork)
        {
            _rentalRepository = rentalRepository;
            _customerRepository = customerRepository;
            _gameRepository = gameRepository;
        }

        public async Task<Result> Handle(InsertRentalRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null) return Result.Failure("O cliente de id " + request.CustomerId + " não existe");

            var game = await _gameRepository.GetByIdAsync(request.GameId);
            if (game == null) return Result.Failure("O game de id " + request.GameId + " não existe");

            var rentalsForGame = await _rentalRepository.GetAllActivedByGameIdAsync(request.GameId);
            var rentalsActivedCount = rentalsForGame is null ? 0 : rentalsForGame.Count();
            if (game.Stock - rentalsActivedCount <= 0) return Result.Failure("Estoque insuficiênte"); 

            var createRentalResult = Rental.Create(
                customer.Id,
                request.DaysRented,
                game
            );

            if (createRentalResult.IsFailure)
            {
                return Result.Failure(createRentalResult.ErrorMessage!);
            }

            await _rentalRepository.CreateAsync(createRentalResult.Value!);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }
    }
}