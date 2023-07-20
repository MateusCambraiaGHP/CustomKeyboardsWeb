using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers
{
    public class CreateSupplierCommand : Command<CreateSupplierCommandResponse>
    {
        public SupplierViewModel SupplierViewModel { get; set; }

        public CreateSupplierCommand(SupplierViewModel model) => SupplierViewModel = model;
    }
}
