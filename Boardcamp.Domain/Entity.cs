using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Domain
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
    }
}
