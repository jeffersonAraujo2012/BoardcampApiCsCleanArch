using Boardcamp.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Domain.Customers.Repositories
{
    public interface ICustomerRepository
    {
        ValueTask<Result> CreateAsync(Customer customer);
        ValueTask<Result> UpdateAsync(Customer customer);
        ValueTask<Customer?> GetByCpfAsync(string cpf);
        ValueTask<Customer?> GetByCpfExcludeAnyByIds(string cpf, IEnumerable<long> ignoreCustomersIds);
        ValueTask<Customer?> GetByIdAsync(long id);
        ValueTask<IEnumerable<Customer>?> GetAllAsync();
    }
}
