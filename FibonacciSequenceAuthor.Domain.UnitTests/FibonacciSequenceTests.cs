using AutoFixture;
using FibonacciSequenceAuthor.Domain.UnitTests.Extensions;
using Xunit;

namespace FibonacciSequenceAuthor.Domain.UnitTests
{
    public class FibonacciSequenceTests
    {
        [Fact]
        public void DefaultInitSequence_Length_Test()
        {
            var defaultInitSequenceLength = 2;

            var sequence = new FibonacciSequence(new long[] { });

            Assert.Equal(sequence.Sequence.Length, defaultInitSequenceLength);
        }

        [Fact]
        public void ContinueSequence_Length_Test()
        {
            var maxSequenceLength = 92;
            var defaultInitSequenceLength = 2;

            var sequence = new FibonacciSequence(new long[] { });

            var fixture = new Fixture();

            var addQuantity = fixture.CreateInt(1, maxSequenceLength - defaultInitSequenceLength);

            for (var i = 0; i < addQuantity; i++) sequence.Continue();

            Assert.Equal(sequence.Sequence.Length, addQuantity + defaultInitSequenceLength);
        }

        [Fact]
        public void ContinueSequence_Values_Test()
        {
            var maxSequenceLength = 92;
            var defaultInitSequenceLength = 2;

            var sequence = new FibonacciSequence(new long[] { });

            var fixture = new Fixture();

            var addQuantity = fixture.CreateInt(1, maxSequenceLength - defaultInitSequenceLength);

            for (var i = 0; i < addQuantity; i++)
            {
                sequence.Continue();
                Assert.Equal(sequence.Sequence[^1], sequence.Sequence[^3] + sequence.Sequence[^2]);
            }
        }
    }
}