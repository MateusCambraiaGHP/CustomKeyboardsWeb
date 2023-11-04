using CustomKeyboardsWeb.Application.Features.Commands.Suppliers;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Suppliers
{
    public class CreateSupplierCommandValidation : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidation()
        {
            RuleFor(c => c.SupplierDto.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
