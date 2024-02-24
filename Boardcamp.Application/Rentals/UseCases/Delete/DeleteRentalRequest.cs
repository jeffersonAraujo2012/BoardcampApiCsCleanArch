using Boardcamp.Domain.Results;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Rentals.UseCases.Delete
{
    public class DeleteRentalRequest : IRequest<Result>
    {
        public long Id { get; set; }
    }
}