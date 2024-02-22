using Boardcamp.Domain.Games;
using Boardcamp.Domain.Games.Repositories;
using Boardcamp.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Games.UseCases.ReadAll
{
    public class ReadAllGamesRequestHandler : IRequestHandler<ReadAllGamesRequest, Result<IEnumerable<Game>?>>
    {
        private readonly IGameRepository _gameRepository;

        public ReadAllGamesRequestHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Result<IEnumerable<Game>?>> Handle(ReadAllGamesRequest request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAllAsync();
            return Result.Success(games);
        }
    }
}
