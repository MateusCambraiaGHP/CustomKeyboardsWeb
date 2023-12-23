using CustomKeyboardsWeb.Application.Dtos.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers
{
    public class CreateSupplierCommand : Command<CreateSupplierCommandResponse>
    {
        public CreateSupplierDto SupplierDto { get; init; }

        public CreateSupplierCommand(CreateSupplierDto model) => SupplierDto = model;
    }
}
