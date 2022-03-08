namespace FibonacciSequenceAuthor.Presentation.RabbitListeners.Contracts
{
    public class ContinueFibonacciSequenceQueueExternal
    {
        public long[] Sequence { get; set; }
        public int RequestedLength { get; set; }
    }
}