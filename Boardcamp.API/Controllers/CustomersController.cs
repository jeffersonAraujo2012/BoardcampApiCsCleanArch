using Boardcamp.Application.Customers.UseCases.ReadAll;
using Boardcamp.Application.Customers.UseCases.ReadById;
using Boardcamp.Domain.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boardcamp.API.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var request = new ReadAllCustomerRequest();

            var readAllResult = await _mediator.Send(request);

            if (readAllResult.IsFailure)
            {
                return BadRequest(readAllResult.ErrorMessage);
            }

            return Ok(readAllResult.Value);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById([FromRoute] int id)
        {
            var request = new ReadByIdCustomerRequest { Id = id };

            var readByIdResult = await _mediator.Send(request);

            if (readByIdResult.IsFailure)
            {
                return BadRequest(readByIdResult.ErrorMessage);
            }

            return Ok(readByIdResult.Value);
        }
    }
}
