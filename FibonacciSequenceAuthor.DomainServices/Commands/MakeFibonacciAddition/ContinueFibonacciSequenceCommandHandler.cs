using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Contracts;
using FibonacciSequenceAuthor.ExternalServices.FibonacciSequenceAssistant;
using FibonacciSequenceAuthor.ExternalServices.FibonacciSequenceAssistant.Converters;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition
{
    public class ContinueFibonacciSequenceCommandHandler : AsyncRequestHandler<ContinueFibonacciSequenceCommand>
    {
        private readonly IFibonacciSequenceAssistantClient _fibonacciSequenceAssistantClient;
        private readonly ILogger<ContinueFibonacciSequenceCommandHandler> _logger;

        public ContinueFibonacciSequenceCommandHandler(
            IFibonacciSequenceAssistantClient fibonacciSequenceAssistantClient,
            ILogger<ContinueFibonacciSequenceCommandHandler> logger)
        {
            _fibonacciSequenceAssistantClient = fibonacciSequenceAssistantClient;
            _logger = logger;
        }

        protected override async Task Handle(ContinueFibonacciSequenceCommand request,
            CancellationToken cancellationToken)
        {
            var sequence = request.FibonacciSequence.ToDomain();

            if (request.FibonacciSequence.Sequence.Length < request.RequestedLength)
            {
                sequence.Continue();

                await _fibonacciSequenceAssistantClient.Continue(sequence.FromDomain(),
                    request.RequestedLength,
                    cancellationToken);
            }
            else
            {
                var message = $"Finished Fibonacci sequence {JsonSerializer.Serialize(sequence.Sequence)}";

                _logger.LogInformation(message);
            }
        }
    }
}