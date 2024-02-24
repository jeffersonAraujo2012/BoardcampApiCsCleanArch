using Boardcamp.Domain.Customers;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Customers.UseCases.ReadById
{
    public class ReadByIdCustomerRequest : IRequest<Result<Customer>>
    {
        public long Id { get; set; }
    }
}
