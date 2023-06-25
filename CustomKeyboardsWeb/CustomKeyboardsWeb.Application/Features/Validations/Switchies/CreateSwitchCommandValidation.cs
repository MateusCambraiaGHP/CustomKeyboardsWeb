using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Switchies
{
    public class CreateSwitchCommandValidation : AbstractValidator<CreateSwitchCommand>
    {
        public CreateSwitchCommandValidation()
        {
            RuleFor(c => c.SwitchViewModel.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
