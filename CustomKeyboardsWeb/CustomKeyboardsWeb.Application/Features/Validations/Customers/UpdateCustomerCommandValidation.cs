using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Customers
{
    public class UpdateCustomerCommandValidation : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            RuleFor(c => c.CustomerDto.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
