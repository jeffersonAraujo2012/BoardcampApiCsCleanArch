using Boardcamp.Domain.Customers;
using Boardcamp.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Customers.UseCases.ReadById
{
    public class ReadByIdRentalRequest : IRequest<Result<Customer>>
    {
        public long Id { get; set; }
    }
}
