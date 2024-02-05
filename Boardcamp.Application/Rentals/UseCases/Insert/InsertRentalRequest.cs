using Boardcamp.Domain.Results;
using MediatR;

namespace Boardcamp.Application.Rentals.UseCases.Insert
{
    public class InsertRentalRequest : IRequest<Result>
    {
        public long CustomerId { get; set; }
        public long GameId { get; set; }
        public int DaysRented { get; set; }
    }
}
