using FibonacciSequenceAuthor.GenericSubdomain;
using MediatR;

namespace FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Contracts
{
    public class ContinueFibonacciSequenceCommand : IRequest
    {
        public readonly FibonacciSequenceDto FibonacciSequence;
        public readonly int RequestedLength;

        public ContinueFibonacciSequenceCommand(FibonacciSequenceDto fibonacciSequence, int requestedLength)
        {
            FibonacciSequence = fibonacciSequence;
            RequestedLength = requestedLength;
        }
    }
}