using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Contracts;
using FibonacciSequenceAuthor.GenericSubdomain;
using FibonacciSequenceAuthor.Presentation.RabbitListeners.Contracts;

namespace FibonacciSequenceAuthor.Presentation.RabbitListeners.Converters
{
    public static class ContinueFibonacciSequenceExternalEventConverter
    {
        public static ContinueFibonacciSequenceCommand ToCommand(
            this ContinueFibonacciSequenceQueueExternal continueFibonacciSequenceExternal)
        {
            return new ContinueFibonacciSequenceCommand(
                new FibonacciSequenceDto(continueFibonacciSequenceExternal.Sequence),
                continueFibonacciSequenceExternal.RequestedLength);
        }
    }
}