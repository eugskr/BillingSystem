﻿using Domain.Models;
using Infrastructure.RecurlyProvider;
using Infrastructure.Repository;


using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecurlyAccountService(this IServiceCollection services)
        {
            
            services.AddSingleton<IDbClient<AccountViewModel>, DbClient<AccountViewModel>>();
            services.AddTransient<IRecurlyAdapter,RecurlyAccount>();
            return services;
        }
    }
}