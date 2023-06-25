using CustomKeyboardsWeb.Application.Features.Commands.Suppliers;
using FluentValidation;

namespace CustomKeyboardsWeb.Application.Features.Validations.Suppliers
{
    public class UpdateSupplierCommandValidation : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidation()
        {
            RuleFor(c => c.SupplierViewModel.Active)
                .NotEmpty().WithMessage("O active não pode ser vazio");
        }
    }
}
