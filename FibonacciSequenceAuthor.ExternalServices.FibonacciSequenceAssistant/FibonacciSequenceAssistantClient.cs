using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FibonacciSequenceAuthor.GenericSubdomain;

namespace FibonacciSequenceAuthor.ExternalServices.FibonacciSequenceAssistant
{
    public class FibonacciSequenceAssistantClient : IFibonacciSequenceAssistantClient
    {
        private readonly FibonacciSequenceAssistantGeneratedClient _client;

        public FibonacciSequenceAssistantClient(FibonacciSequenceAssistantServiceConfiguration clientConfiguration)
        {
            _client = new FibonacciSequenceAssistantGeneratedClient(clientConfiguration.BaseUrl, new HttpClient());
        }

        public async Task Continue(FibonacciSequenceDto fibonacciSequence,
            int requestedLength,
            CancellationToken cancellationToken)
        {
            var body = new ContinueFibonacciSequenceExternal
            {
                Sequence = fibonacciSequence.Sequence,
                RequestedLength = requestedLength
            };
            await _client.ContinueAsync(body, cancellationToken);
        }
    }
}