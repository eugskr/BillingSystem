using Domain.RepositoryModels;
using Domain.WebHookNotificationModels;
using Infrastructure.RecurlyProvider;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecurlyService(this IServiceCollection services)
        {          
            services.AddSingleton<IDbRepository<Domain.RepositoryModels.Account>, DbRepository<Domain.RepositoryModels.Account>>();
            services.AddSingleton<IDbRepository<PaymentNotificationBase>, DbRepository<PaymentNotificationBase>>();
            services.AddTransient<IRecurlyAdapter,RecurlyAdapter>();
            return services;
        }
    }
}
