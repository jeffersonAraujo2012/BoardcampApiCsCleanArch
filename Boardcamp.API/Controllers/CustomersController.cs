using Boardcamp.Application.Customers.UseCases.ReadAll;
using Boardcamp.Application.Customers.UseCases.ReadById;
using Boardcamp.Application.Customers.UseCases.Upsert;
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

        [HttpPost]
        public async Task<IActionResult> InsertCustomer(UpsertCustomerRequest request)
        {
            var insertResult = await _mediator.Send(request);

            if (insertResult.IsFailure)
            {
                return BadRequest(insertResult.ErrorMessage);
            }

            return Created();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(UpsertCustomerRequest request, [FromRoute] int id)
        {
            request.Id = id;

            var updateResult = await _mediator.Send(request);

            if (updateResult.IsFailure)
            {
                return BadRequest(updateResult.ErrorMessage);
            }

            return Ok();
        }
    }
}
