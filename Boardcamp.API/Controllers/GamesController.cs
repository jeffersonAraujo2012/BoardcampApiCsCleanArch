using Boardcamp.Application.Games.UseCases.ReadAll;
using Boardcamp.Domain.Games;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boardcamp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
        {
            var request = new ReadAllGamesRequest();

            var games = await _mediator.Send(request);

            if (games.IsFailure)
            {
                return BadRequest(games.ErrorMessage);
            }

            return Ok(games.Value);
        }
    }
}
