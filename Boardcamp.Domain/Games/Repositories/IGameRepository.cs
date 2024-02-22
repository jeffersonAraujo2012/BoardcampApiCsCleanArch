using Boardcamp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Domain.Games.Repositories
{
    public interface IGameRepository
    {
        ValueTask<Result> CreateAsync(Game game);
        ValueTask<Result> UpdateAsync(Game game);
        ValueTask<Game?> GetOneByNameAsync(string name);
        ValueTask<Game?> GetByIdAsync(long id);
        ValueTask<IEnumerable<Game>?> GetAllAsync();

    }
}
