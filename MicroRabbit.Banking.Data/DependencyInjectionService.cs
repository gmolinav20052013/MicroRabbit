using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Banking.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddDbContext<BankingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BakingDbConnection")));

            return services;
        }
    }
}
