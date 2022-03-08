using FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Contracts;
using FluentValidation;

namespace FibonacciSequenceAuthor.DomainServices.Commands.MakeFibonacciAddition.Validators
{
    public class MaxSequenceLengthValidator : AbstractValidator<ContinueFibonacciSequenceCommand>
    {
        private const int MaxFibonacciSequenceLength = 92;

        public MaxSequenceLengthValidator()
        {
            RuleFor(x => x.RequestedLength)
                .LessThanOrEqualTo(MaxFibonacciSequenceLength)
                .WithMessage(command =>
                    $"Sequence length must be equal or lower than {MaxFibonacciSequenceLength}" +
                    $",you entered: {command.RequestedLength}");
        }
    }
}