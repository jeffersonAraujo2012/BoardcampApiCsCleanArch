using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Customers.UseCases.Upsert
{
    public class UpsertCustomerRequest : IRequest<Result>
    {
        public long? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public DateOnly Birthday { get; set; }
    }
}
