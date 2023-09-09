using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Switchies
{
    public class UpdateSwitchCommandValidation : AbstractValidator<UpdateSwitchCommand>
    {
        public UpdateSwitchCommandValidation()
        {
            RuleFor(c => c.SwitchViewModel.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
