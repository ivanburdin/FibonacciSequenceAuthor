using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FibonacciSequenceAuthor.ExternalServices.FibonacciSequenceAssistant
{
    public static class FibonacciSequenceAssistantRegistrar
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            var fibonacciSequenceAssistantClientConfiguration = configuration
                .GetSection(nameof(FibonacciSequenceAssistantServiceConfiguration))
                .Get<FibonacciSequenceAssistantServiceConfiguration>();

            services.AddSingleton(fibonacciSequenceAssistantClientConfiguration);

            services.AddSingleton<IFibonacciSequenceAssistantClient, FibonacciSequenceAssistantClient>();
        }
    }
}