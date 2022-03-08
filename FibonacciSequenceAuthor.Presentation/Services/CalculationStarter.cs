using System.Threading;
using System.Threading.Tasks;
using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Contracts;
using FibonacciSequenceAuthor.GenericSubdomain;
using FibonacciSequenceAuthor.GenericSubdomain.Options;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FibonacciSequenceAuthor.Presentation.Services
{
    public class CalculationStarter : IHostedService
    {
        private readonly ILogger<CalculationStarter> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IValidator<ContinueFibonacciSequenceCommand> _validator;

        public CalculationStarter(IMediator mediator, IConfiguration configuration,
            IValidator<ContinueFibonacciSequenceCommand> validator, ILogger<CalculationStarter> logger)
        {
            _mediator = mediator;
            _configuration = configuration;
            _validator = validator;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var calculationOptions = _configuration
                .GetSection(nameof(FibonacciCalculationOptions))
                .Get<FibonacciCalculationOptions>();

            var command =
                new ContinueFibonacciSequenceCommand(FibonacciSequenceDto.Empty(), calculationOptions.RequestedLength);

            await _validator.ValidateAndThrowAsync(command, cancellationToken);

            await _mediator.Send(command, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}