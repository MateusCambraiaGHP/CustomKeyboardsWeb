using FluentValidation;

namespace CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards
{
    public class KeyboardValidator : AbstractValidator<Keyboard>
    {
        public KeyboardValidator()
        {
            RuleFor(product => product.Price.Value)
                .GreaterThan(0.0)
                .WithMessage("The price must be greater than zero.");
        }
    }
}
