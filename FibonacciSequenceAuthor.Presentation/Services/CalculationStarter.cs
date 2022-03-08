using System.Threading;
using System.Threading.Tasks;
using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Contracts;
using FibonacciSequenceAuthor.GenericSubdomain;
using FibonacciSequenceAuthor.GenericSubdomain.Options;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Namotion.Reflection;

namespace FibonacciSequenceAuthor.Presentation.Services
{
    public class CalculationStarter : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IValidator<ContinueFibonacciSequenceCommand> _validator;

        public CalculationStarter(IMediator mediator, IConfiguration configuration,
            IValidator<ContinueFibonacciSequenceCommand> validator)
        {
            _mediator = mediator;
            _configuration = configuration;
            _validator = validator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var calculationOptions = _configuration
                .GetSection(nameof(FibonacciCalculationOptions))
                .Get<FibonacciCalculationOptions>();

            var command =
                new ContinueFibonacciSequenceCommand(FibonacciSequenceDto.Empty(), calculationOptions.RequestedLength);

            await _validator.ValidateAndThrowAsync(command, cancellationToken);

            command.ValidateNullability();
            await _mediator.Send(command, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult("Stopped");
        }
    }
}