using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Worker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Worker";

            var endpointConfiguration = new EndpointConfiguration("Worker");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
