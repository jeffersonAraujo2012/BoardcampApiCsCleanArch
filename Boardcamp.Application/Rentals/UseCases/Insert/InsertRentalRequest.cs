using Boardcamp.Domain.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.Rentals.UseCases.Insert
{
    public class InsertRentalRequest : IRequest<Result>
    {
        public long CustomerId { get; set; }
        public long GameId { get; set; }
        public int DaysRented { get; set; }
    }
}
