using Boardcamp.Domain.Results;

namespace Boardcamp.Domain.Rentals.Repositories
{
    public interface IRentalRepository
    {
        ValueTask<Result> CreateAsync(Rental rental);
        ValueTask<IEnumerable<Rental>> GetAllActivedByGameIdAsync(long gameId);
    }
}
