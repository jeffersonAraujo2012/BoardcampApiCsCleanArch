using Boardcamp.Domain.Customers;
using Boardcamp.Domain.Customers.Repositories;
using Boardcamp.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Customers.UseCases.Upsert
{
    public class UpsertCustomerRequestHandler : IRequestHandler<UpsertCustomerRequest, Result>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpsertCustomerRequestHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result> Handle(UpsertCustomerRequest request, CancellationToken cancellationToken)
        {
            return request.Id is null ? 
                await Create(request, cancellationToken) : 
                await Update(request, cancellationToken);
        }

        private async ValueTask<Result> Create(UpsertCustomerRequest request, CancellationToken cancellationToken)
        {
            var customerSameCpf = await _customerRepository.GetByCpfAsync(request.Cpf);
            if (customerSameCpf is not null) return Result.Failure("Usuário já existe.");

            var customer = Customer.Create(
                request.Name,
                request.Phone,
                request.Cpf,
                request.Birthday
            );

            if (customer.IsFailure)
            {
                return Result.Failure(customer.ErrorMessage!);
            }

            await _customerRepository.CreateAsync(customer.Value!);

            return Result.Success();
        }

        private async ValueTask<Result> Update(UpsertCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id ?? 0);
            if (customer is null) return Result.Failure("Cliente não encontrado na base do sistema");

            var otherCustomerSameCpf = await _customerRepository.GetByCpfExcludeAnyByIdsAsync(request.Cpf, new List<long> { request.Id ?? 0 });
            if (otherCustomerSameCpf is not null) return Result.Failure("Já existe outro usuário com o mesmo cpf cadastrado.");

            var updateResult = customer.Update(
                request.Name,
                request.Phone,
                request.Cpf,
                request.Birthday
            );

            if (updateResult.IsFailure)
            {
                return updateResult;
            }

            await _customerRepository.UpdateAsync(customer);

            return Result.Success();
        }
    }
}