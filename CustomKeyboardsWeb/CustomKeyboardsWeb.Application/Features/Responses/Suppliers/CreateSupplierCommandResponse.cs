using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;


namespace CustomKeyboardsWeb.Application.Features.Responses.Suppliers
{
    public class CreateSupplierCommandResponse : BaseHandlerResponse
    {
        public SupplierViewModel Supplier { get; set; }

        public CreateSupplierCommandResponse() { }

        public CreateSupplierCommandResponse(SupplierViewModel supplier)
            : base() => Supplier = supplier;

        public CreateSupplierCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
