using CustomKeyboardsWeb.Application.Dtos.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers
{
    public class UpdateSupplierCommand : Command<UpdateSupplierCommandResponse>
    {
        public UpdateSupplierDto SupplierDto { get; init; }

        public UpdateSupplierCommand(UpdateSupplierDto model) => SupplierDto = model;
    }
}
