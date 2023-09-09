using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Customers
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(c => c.CustomerViewModel.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
