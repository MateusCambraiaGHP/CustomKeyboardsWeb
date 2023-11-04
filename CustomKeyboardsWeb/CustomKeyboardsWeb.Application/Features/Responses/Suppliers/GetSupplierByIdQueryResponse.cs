using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Suppliers
{
    public class GetSupplierByIdQueryResponse : BaseHandlerResponse
    {
        public SupplierViewModel Supplier { get; set; }

        public GetSupplierByIdQueryResponse()
            : base() { }

        public GetSupplierByIdQueryResponse(SupplierViewModel supplierViewModel)
            : base() => Supplier = supplierViewModel;

        public GetSupplierByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
