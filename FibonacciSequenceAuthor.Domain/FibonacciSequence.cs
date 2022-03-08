using System.Collections.Generic;
using System.Linq;

namespace FibonacciSequenceAuthor.Domain
{
    public class FibonacciSequence
    {
        public FibonacciSequence(long[] sequence)
        {
            if (sequence.Any())
            {
                Sequence = sequence;
            }
            else
            {
                var defaultStartSequence = new long[] {1, 1};
                Sequence = defaultStartSequence;
            }
        }

        public long[] Sequence { get; private set; }

        public void Continue()
        {
            var newSequence = new List<long>();

            newSequence.AddRange(Sequence);

            newSequence.Add(Sequence[^2] + Sequence[^1]);

            Sequence = newSequence.ToArray();
        }
    }
}