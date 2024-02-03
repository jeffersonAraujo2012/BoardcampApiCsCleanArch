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
        ValueTask<Result> Create(Game game);
        ValueTask<Result> Update(Game game);
        ValueTask<Game?> GetOneByName(string name);
        ValueTask<Game?> GetById(int id);

    }
}
