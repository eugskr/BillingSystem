using Application.RecurlyRepository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Extensions;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecurlyRepoService(this IServiceCollection services)
        {
            services.AddTransient<IRecurlyRepo, RecurlyRepo>();
            services.AddRecurlyAccountService();
            return services;
        }
    }
}
