using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartParker.Domain.Interfaces;
using SmartParker.Infrastructure.Data;
using SmartParker.Infrastructure.Repositories;

namespace SmartParker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SmartParkerDbContext>(options =>
                options.UseOracle(connectionString));

            services.AddScoped<IMotoRepository, MotoRepository>();

            return services;
        }
    }
}