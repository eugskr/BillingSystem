using Infrastructure.RecurlyProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecurlyService(this IServiceCollection services)
        {    
            services.AddTransient<IRecurlyAdapter,RecurlyAdapter>();
            return services;
        }
    }
}
