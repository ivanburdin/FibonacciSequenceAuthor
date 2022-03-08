using FibonacciSequenceAuthor.Domain;

namespace FibonacciSequenceAuthor.GenericSubdomain
{
    public class FibonacciSequenceDto
    {
        public readonly long[] Sequence;

        public FibonacciSequenceDto(long[] sequence)
        {
            Sequence = sequence;
        }

        public static FibonacciSequenceDto Empty()
        {
            var emptySequence = new long[] { };

            return new FibonacciSequenceDto(emptySequence);
        }

        public FibonacciSequence ToDomain()
        {
            return new FibonacciSequence(Sequence);
        }
    }
}