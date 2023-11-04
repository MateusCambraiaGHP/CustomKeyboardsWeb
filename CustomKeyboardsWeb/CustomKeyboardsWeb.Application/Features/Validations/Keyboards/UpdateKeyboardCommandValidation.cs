using CustomKeyboardsWeb.Application.Features.Commands.Keyboards;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Keyboards
{
    public class UpdateKeyboardCommandValidation : AbstractValidator<UpdateKeyboardCommand>
    {
        public UpdateKeyboardCommandValidation()
        {
            RuleFor(c => c.KeyboardDto.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
