using System.Threading;
using System.Threading.Tasks;
using FibonacciSequenceAuthor.GenericSubdomain;

namespace FibonacciSequenceAuthor.ExternalServices.FibonacciSequenceAssistant
{
    public interface IFibonacciSequenceAssistantClient
    {
        Task Continue(FibonacciSequenceDto fibonacciSequence, int requestedLength, CancellationToken cancellationToken);
    }
}