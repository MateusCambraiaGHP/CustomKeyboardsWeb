using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Suppliers
{
    public class UpdateSupplierCommandResponse : BaseHandlerResponse
    {
        public SupplierViewModel Supplier { get; set; }

        public UpdateSupplierCommandResponse() { }

        public UpdateSupplierCommandResponse(SupplierViewModel supplier)
            : base() => Supplier = supplier;

        public UpdateSupplierCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
