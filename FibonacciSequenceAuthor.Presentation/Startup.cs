using FibonacciSequenceAuthor.DomainServices;
using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Contracts;
using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Validators;
using FibonacciSequenceAuthor.ExternalServices.FibonacciSequenceAssistant;
using FibonacciSequenceAuthor.Presentation.Extensions;
using FibonacciSequenceAuthor.Presentation.RabbitListeners;
using FibonacciSequenceAuthor.Presentation.RabbitListeners.Options;
using FibonacciSequenceAuthor.Presentation.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FibonacciSequenceAuthor.Presentation
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var rabbitOptions = Configuration.GetSection(nameof(RabbitOptions)).Get<RabbitOptions>();
            services.AddSingleton(rabbitOptions);
            services.AddSingleton<FibonacciSequenceRabbitListener>();

            DomainServicesRegistrar.Configure(Configuration, services);
            FibonacciSequenceAssistantRegistrar.Configure(Configuration, services);

            services.AddTransient<IValidator<ContinueFibonacciSequenceCommand>, MaxSequenceLengthValidator>();

            services.AddHostedService<CalculationStarter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseRabbitListener();
        }
    }
}