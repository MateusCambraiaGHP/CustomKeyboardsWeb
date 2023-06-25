using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Customers
{
    public class UpdateCustomerCommandValidation : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            RuleFor(c => c.CustomerViewModel.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
