using Application.Providers;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Extensions;
using System;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IBillingPaymentProvider, BillingPaymentProvider>();
            services.AddRecurlyService();
            return services;
        }
    }
}
