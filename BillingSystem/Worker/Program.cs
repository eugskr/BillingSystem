using NServiceBus;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repository;
using Domain.RepositoryModels;
using Domain.WebHookNotificationModels;

namespace Worker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Worker";

            var endpointConfiguration = new EndpointConfiguration("Worker");
            endpointConfiguration.UseTransport<LearningTransport>();
            //endpointConfiguration.UsePersistence<LearningPersistence>();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IDbRepository<Domain.RepositoryModels.Account>, DbRepository<Domain.RepositoryModels.Account>>();
            serviceCollection.AddScoped<IDbRepository<PaymentNotificationBase>, DbRepository<PaymentNotificationBase>>();

            var endpointWithExternallyManagedServiceProvider = EndpointWithExternallyManagedServiceProvider
            .Create(endpointConfiguration, serviceCollection);

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var endpointInstance = await endpointWithExternallyManagedServiceProvider.Start(serviceProvider)
                   .ConfigureAwait(false);

                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();

                await endpointInstance.Stop()
                    .ConfigureAwait(false);
            }              

           
        }
    }
}
