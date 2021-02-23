using Domain.RepositoryModels;
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
            services.AddSingleton<IDbRepository<Account>, DbRepository<Account>>();
            services.AddTransient<IRecurlyAdapter,RecurlyAdapter>();
            return services;
        }
    }
}
