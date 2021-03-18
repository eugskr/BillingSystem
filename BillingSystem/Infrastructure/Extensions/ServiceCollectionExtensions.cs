using Domain.RepositoryModels;
using Domain.WebHookNotificationModels;
using Infrastructure.RecurlyProvider;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecurlyService(this IServiceCollection services)
        {
            services.AddScoped<IDbRepository<Domain.RepositoryModels.Account>, DbRepository<Domain.RepositoryModels.Account>>();
            services.AddScoped<IDbRepository<PaymentNotificationBase>, DbRepository<PaymentNotificationBase>>();
            services.AddScoped<IDbRepository<Invoice>, DbRepository<Invoice>>();
            services.AddTransient<IRecurlyAdapter,RecurlyAdapter>();
            return services;
        }
    }
}
