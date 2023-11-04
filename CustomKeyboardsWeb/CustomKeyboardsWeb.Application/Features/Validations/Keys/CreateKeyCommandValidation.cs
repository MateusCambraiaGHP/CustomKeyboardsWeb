using CustomKeyboardsWeb.Application.Features.Commands.Keys;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Keys
{
    public class CreateKeyCommandValidation : AbstractValidator<CreateKeyCommand>
    {
        public CreateKeyCommandValidation()
        {
            RuleFor(c => c.KeyDto.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
