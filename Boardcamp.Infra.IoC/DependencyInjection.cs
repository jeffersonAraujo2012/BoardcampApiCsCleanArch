using Boardcamp.Domain;
using Boardcamp.Domain.Customers.Repositories;
using Boardcamp.Domain.Games.Repositories;
using Boardcamp.Domain.Rentals.Repositories;
using Boardcamp.Infra.Data;
using Boardcamp.Infra.Data.Contexts;
using Boardcamp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Boardcamp.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DevConnectionString"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                )
            );

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var myHandlers = AppDomain.CurrentDomain.Load("Boardcamp.Application");
            services.AddMediatR(p => p.RegisterServicesFromAssembly(myHandlers));

            return services;
        }
    }
}
