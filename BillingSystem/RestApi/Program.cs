using Domain.RepositoryModels;
using Domain.WebHookNotificationModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseNServiceBus(context =>
             {
                 var endpointConfiguration = new EndpointConfiguration("RestApi");
                 var transport = endpointConfiguration.UseTransport<LearningTransport>();
                 var routing = transport.Routing();
                 routing.RouteToEndpoint(
                    assembly: typeof(Domain.RepositoryModels.Account).Assembly,
                    destination: "Worker");
                 routing.RouteToEndpoint(
                    typeof(PaymentNotificationBase),
                    destination: "Worker");
                 endpointConfiguration.SendOnly();
                 return endpointConfiguration;
             })
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
