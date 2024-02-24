using Boardcamp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Application.HandlersBase
{
    public abstract class HandlerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public HandlerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
