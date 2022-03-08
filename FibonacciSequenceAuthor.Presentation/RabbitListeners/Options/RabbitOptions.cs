namespace FibonacciSequenceAuthor.Presentation.RabbitListeners.Options
{
    public class RabbitOptions
    {
        public string Queue { get; set; }
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}