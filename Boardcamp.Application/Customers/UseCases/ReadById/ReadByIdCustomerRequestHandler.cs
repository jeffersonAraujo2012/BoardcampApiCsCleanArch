using Boardcamp.Domain.Customers;
using Boardcamp.Domain.Customers.Repositories;
using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Customers.UseCases.ReadById
{
    public class ReadByIdCustomerRequestHandler : IRequestHandler<ReadByIdCustomerRequest, Result<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public ReadByIdCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<Customer>> Handle(ReadByIdCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null) return Result.Failure<Customer>("O cliente de id " + request.Id + "não foi encontrado");

            return Result.Success(customer);
        }
    }
}
