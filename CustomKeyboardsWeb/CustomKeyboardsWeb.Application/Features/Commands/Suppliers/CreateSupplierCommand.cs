using CustomKeyboardsWeb.Application.Dtos.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers
{
    public class CreateSupplierCommand : Command<CreateSupplierCommandResponse>
    {
        public SupplierDto SupplierDto { get; set; }

        public CreateSupplierCommand(SupplierDto model) => SupplierDto = model;
    }
}
