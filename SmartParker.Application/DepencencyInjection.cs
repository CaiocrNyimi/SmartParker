using Microsoft.Extensions.DependencyInjection;
using SmartParker.Application.Services;

namespace SmartParker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMotoService, MotoService>();
            return services;
        }
    }
}