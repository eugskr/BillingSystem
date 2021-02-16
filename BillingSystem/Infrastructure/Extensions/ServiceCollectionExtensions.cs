using Infrastructure.RecurlyProvider;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecurlyAccountService(this IServiceCollection services)
        {
            services.AddTransient<IRecurlyAccount,RecurlyAccount>();
            return services;
        }
    }
}
