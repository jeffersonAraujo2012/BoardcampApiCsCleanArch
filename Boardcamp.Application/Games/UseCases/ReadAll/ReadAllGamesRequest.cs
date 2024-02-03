using Boardcamp.Domain.Games;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Games.UseCases.ReadAll
{
    public class ReadAllGamesRequest : IRequest<Result<IEnumerable<Game>?>>
    {
    }
}
