﻿using Boardcamp.Domain.Results;

namespace Boardcamp.Domain.Rentals.Repositories
{
    public interface IRentalRepository
    {
        ValueTask<Result> CreateAsync(Rental rental);
        ValueTask<IEnumerable<Rental>> GetAllActivedByGameIdAsync(long gameId);
        ValueTask<Rental?> GetByIdAsync(long id);
        ValueTask<IEnumerable<Rental>?> GetAllAsync();
        ValueTask<Result> DeleteAsync(Rental rental);
        ValueTask<Result> UpdateAsync(Rental rental);
    }
}
