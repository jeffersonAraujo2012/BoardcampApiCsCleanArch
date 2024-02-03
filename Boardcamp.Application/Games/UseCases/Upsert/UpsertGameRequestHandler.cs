using Boardcamp.Domain.Games;
using Boardcamp.Domain.Games.Repositories;
using Boardcamp.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Games.UseCases.Upsert
{
    public class UpsertGameRequestHandler : IRequestHandler<UpsertGameRequest, Result>
    {
        private readonly IGameRepository _gameRepository;

        public UpsertGameRequestHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Result> Handle(UpsertGameRequest request, CancellationToken cancellationToken)
        {
            if (request.Id is not null)
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
            var gameSameName = await _gameRepository.GetOneByName(request.Name);
            if (gameSameName is null) return Result.Failure("Já existe um jogo com o mesmo nome. Use um nome diferente.");

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

            return Result.Success();
        }

        private async ValueTask<Result> Update(UpsertGameRequest request, CancellationToken cancellationToken)
        {
            return Result.Failure("Caso de uso não implementado.");
        }
    }
}
