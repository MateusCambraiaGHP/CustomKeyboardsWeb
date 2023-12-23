using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Customers
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(c => c.CustomerDto.Active)
                .NotEmpty().WithMessage("The active cannot be empty");
            RuleFor(c => c.CustomerDto.Address)
                .NotEmpty().WithMessage("The Address cannot be empty");
            RuleFor(c => c.CustomerDto.Name)
                .NotEmpty().WithMessage("The Name cannot be empty");
            RuleFor(c => c.CustomerDto.Cep)
                .NotEmpty().WithMessage("The Cep cannot be empty");
            RuleFor(c => c.CustomerDto.FederativeUnit)
                .NotEmpty().WithMessage("The FederativeUnit cannot be empty");
            RuleFor(c => c.CustomerDto.FantasyName)
                .NotEmpty().WithMessage("The FantasyName cannot be empty");
            RuleFor(c => c.CustomerDto.Phone)
                .NotEmpty().WithMessage("The Phone cannot be empty");
        }
    }
}
