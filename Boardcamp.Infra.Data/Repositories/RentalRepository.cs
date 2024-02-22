using Boardcamp.Domain.Rentals;
using Boardcamp.Domain.Rentals.Repositories;
using Boardcamp.Domain.Results;
using Boardcamp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Infra.Data.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public RentalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask<Result> CreateAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await Task.CompletedTask;
            return Result.Success();
        }

        public async ValueTask<IEnumerable<Rental>> GetAllActivedByGameIdAsync(long gameId)
        {
            return await _context.Rentals.Where(r => r.GameId == gameId && r.ReturnDate == null).ToListAsync();
        }

        public async ValueTask<Rental?> GetByIdAsync(long id)
        {
            return await _context.Rentals.SingleOrDefaultAsync(r => r.Id == id);
        }
    }
}
