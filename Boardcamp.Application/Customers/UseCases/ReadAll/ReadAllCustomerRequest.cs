using Boardcamp.Domain.Customers;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Customers.UseCases.ReadAll
{
    public class ReadAllCustomerRequest : IRequest<Result<IEnumerable<Customer>>>
    {
    }
}