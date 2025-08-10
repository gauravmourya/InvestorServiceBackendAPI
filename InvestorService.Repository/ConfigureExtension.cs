using InvestorService.Repository.Database;
using InvestorService.Repository.DatabaseOperations.Implementation;
using InvestorService.Repository.DatabaseOperations.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestorService.Repository
{
    public static class ConfigureExtension
    {
        public static IServiceCollection AddInvestorServiceRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IInvestorTypeRepository, InvestorTypeRepository>();
            services.AddScoped<IInvestorRepository, InvestorRepository>();

            return services;
        }
    }
}
