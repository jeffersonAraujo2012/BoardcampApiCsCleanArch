using Boardcamp.Domain.Customers;
using Boardcamp.Domain.Customers.Repositories;
using Boardcamp.Domain.Games;
using Boardcamp.Domain.Results;
using Boardcamp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Boardcamp.Infra.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask<Result> CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await Task.CompletedTask;
            return Result.Success();
        }

        public async ValueTask<IEnumerable<Customer>?> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async ValueTask<Customer?> GetByCpfAsync(string cpf)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Cpf == cpf);
        }

        public async ValueTask<Customer?> GetByCpfExcludeAnyByIdsAsync(string cpf, IEnumerable<long> ignoreCustomersIds)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Cpf == cpf && !ignoreCustomersIds.Any(ignoreId => ignoreId == c.Id));
        }

        public async ValueTask<Customer?> GetByIdAsync(long id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async ValueTask<Result> UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await Task.CompletedTask;
            return Result.Success();
        }
    }
}
