using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FibonacciSequenceAuthor.DomainServices
{
    public static class DomainServicesRegistrar
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            services.AddMediatR(typeof(ContinueFibonacciSequenceCommandHandler));
        }
    }
}