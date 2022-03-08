using FibonacciSequenceAuthor.Domain;
using FibonacciSequenceAuthor.GenericSubdomain;

namespace FibonacciSequenceAuthor.ExternalServices.FibonacciSequenceAssistant.Converters
{
    public static class FibonacciSequenceDtoConverter
    {
        public static FibonacciSequenceDto FromDomain(this FibonacciSequence fibonacciSequence)
        {
            return new FibonacciSequenceDto(fibonacciSequence.Sequence);
        }
    }
}