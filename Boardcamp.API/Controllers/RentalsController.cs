using Boardcamp.Application.Customers.UseCases.ReadById;
using Boardcamp.Application.Rentals.UseCases.Delete;
using Boardcamp.Application.Rentals.UseCases.Insert;
using Boardcamp.Application.Rentals.UseCases.ReadAll;
using Boardcamp.Application.Rentals.UseCases.Return;
using Boardcamp.Domain.Rentals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boardcamp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetAllRentals()
        {
            var request = new ReadAllRentalsRequest();

            var resultRequest = await _mediator.Send(request);

            if (resultRequest.IsFailure)
            {
                return BadRequest(resultRequest.ErrorMessage);
            }

            return Ok(resultRequest.Value);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Rental>> GetRentalById([FromRoute] int id)
        {
            var request = new ReadByIdRentalRequest { Id = id };
            
            var resultRequest = await _mediator.Send(request);

            if (resultRequest.IsFailure)
            {
                return BadRequest(resultRequest.ErrorMessage);
            }

            return Ok(resultRequest.Value);
        }

        [HttpPost]
        public async Task<IActionResult> InsertRental(InsertRentalRequest request)
        {
            var resultRequest = await _mediator.Send(request);

            if (resultRequest.IsFailure)
            {
                return BadRequest(resultRequest.ErrorMessage);
            }

            return Created();
        }

        [HttpPatch]
        [Route("{id}/finalizar")]
        public async Task<IActionResult> ReturnRentalById([FromRoute] int id)
        {
            var request = new ReturnRentalRequest { Id = id };

            var resultRequest = await _mediator.Send(request);

            if (resultRequest.IsFailure)
            {
                return BadRequest(resultRequest.ErrorMessage);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var request = new DeleteRentalRequest { Id = id };

            var resultRequest = await _mediator.Send(request);

            if (resultRequest.IsFailure)
            {
                return BadRequest(resultRequest.ErrorMessage);
            }

            return NoContent();
        }
    }
}
