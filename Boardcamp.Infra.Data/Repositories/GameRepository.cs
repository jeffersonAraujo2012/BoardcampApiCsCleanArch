using Boardcamp.Domain.Games;
using Boardcamp.Domain.Games.Repositories;
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
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask<Result> CreateAsync(Game game)
        {
            _context.Games.Add(game);
            await Task.CompletedTask;
            return Result.Success();
        }

        public async ValueTask<IEnumerable<Game>?> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async ValueTask<Game?> GetByIdAsync(long id)
        {
            return await _context.Games.SingleOrDefaultAsync(g => g.Id == id);
        }

        public async ValueTask<Game?> GetOneByNameAsync(string name)
        {
            return await _context.Games.SingleOrDefaultAsync(g => g.Name == name);
        }

        public async ValueTask<Result> UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await Task.CompletedTask;
            return Result.Success();
        }
    }
}
