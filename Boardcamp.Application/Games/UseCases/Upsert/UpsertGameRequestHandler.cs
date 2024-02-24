using Boardcamp.Application.HandlersBase;
using Boardcamp.Domain;
using Boardcamp.Domain.Games;
using Boardcamp.Domain.Games.Repositories;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Games.UseCases.Upsert
{
    public class UpsertGameRequestHandler : HandlerBase, IRequestHandler<UpsertGameRequest, Result>
    {
        private readonly IGameRepository _gameRepository;

        public UpsertGameRequestHandler(IUnitOfWork unitOfWork, IGameRepository gameRepository) : base(unitOfWork)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Result> Handle(UpsertGameRequest request, CancellationToken cancellationToken)
        {
            if (request.Id is null)
            {
                return await Create(request, cancellationToken);
            }
            else
            {
                return await Update(request, cancellationToken);
            }
        }

        private async ValueTask<Result> Create(UpsertGameRequest request, CancellationToken cancellationToken)
        {
            var gameSameName = await _gameRepository.GetOneByNameAsync(request.Name);
            if (gameSameName is not null) return Result.Failure("Já existe um jogo com o mesmo nome. Use um nome diferente.");

            var game = Game.Criar(
                request.Name,
                request.Image,
                request.Stock,
                request.PricePerDay
            );

            if (game.IsFailure)
            {
                return Result.Failure(game.ErrorMessage!);
            }

            var createResult = await _gameRepository.CreateAsync(game.Value!);

            if (createResult.IsFailure)
            {
                return createResult;
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }

        private async ValueTask<Result> Update(UpsertGameRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Result.Failure("Caso de uso não implementado.");
        }
    }
}