using Boardcamp.Application.Games.UseCases.ReadAll;
using Boardcamp.Application.Games.UseCases.Upsert;
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

        [HttpPost]
        public async Task<IActionResult> InsertGames(UpsertGameRequest request)
        {
            var resultInsert = await _mediator.Send(request);

            if (resultInsert.IsFailure)
            {
                return BadRequest(resultInsert.ErrorMessage);
            }

            return Created();
        }
    }
}
