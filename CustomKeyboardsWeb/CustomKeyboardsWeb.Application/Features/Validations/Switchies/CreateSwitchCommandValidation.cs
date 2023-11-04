using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Switchies
{
    public class CreateSwitchCommandValidation : AbstractValidator<CreateSwitchCommand>
    {
        public CreateSwitchCommandValidation()
        {
            RuleFor(c => c.SwitchDto.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
