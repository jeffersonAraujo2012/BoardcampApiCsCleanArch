using Boardcamp.Application.Customers.UseCases.ReadAll;
using Boardcamp.Domain.Customers;
using Boardcamp.Domain.Customers.Repositories;
using Boardcamp.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Customers.UseCases.Read
{
    public class ReadAllCustomerRequestHandler : IRequestHandler<ReadAllCustomerRequest, Result<IEnumerable<Customer>?>>
    {
        private readonly ICustomerRepository _customerRepository;

        public ReadAllCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<IEnumerable<Customer>?>> Handle(ReadAllCustomerRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();
            return Result.Success(customers);
        }
    }
}
