using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers
{
    public class UpdateSupplierCommand : Command<UpdateSupplierCommandResponse>
    {
        public SupplierViewModel SupplierViewModel { get; set; }

        public UpdateSupplierCommand(SupplierViewModel model) => SupplierViewModel = model;
    }
}
