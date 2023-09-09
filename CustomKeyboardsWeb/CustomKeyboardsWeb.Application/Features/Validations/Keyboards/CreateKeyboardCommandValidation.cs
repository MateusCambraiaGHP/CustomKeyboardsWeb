using CustomKeyboardsWeb.Application.Features.Commands.Keyboards;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Keyboards
{
    public class CreateKeyboardCommandValidation : AbstractValidator<CreateKeyboardCommand>
    {
        public CreateKeyboardCommandValidation()
        {
            RuleFor(c => c.KeyboardViewModel.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
