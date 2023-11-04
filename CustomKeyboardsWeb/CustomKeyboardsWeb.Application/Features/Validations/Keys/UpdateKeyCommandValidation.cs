using CustomKeyboardsWeb.Application.Features.Commands.Keys;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Keys
{
    public class UpdateKeyCommandValidation : AbstractValidator<UpdateKeyCommand>
    {
        public UpdateKeyCommandValidation()
        {
            RuleFor(c => c.KeyDto.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
