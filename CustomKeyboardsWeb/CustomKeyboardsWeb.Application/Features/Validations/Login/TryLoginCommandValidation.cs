using CustomKeyboardsWeb.Application.Features.Commands.Login;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Login
{
    public class TryLoginCommandValidation : AbstractValidator<TryLoginCommand>
    {
        public TryLoginCommandValidation()
        {
            RuleFor(c => c.LoginViewModel.Email)
                .NotEmpty().WithMessage("O Email não pode ser vazio");

            RuleFor(c => c.LoginViewModel.Password)
                .NotEmpty().WithMessage("A Senha não pode ser vazia");
        }
    }
}
