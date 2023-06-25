using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Suppliers
{
    public class GetSupplierListQueryResponse : BaseHandlerResponse
    {
        public List<SupplierViewModel> Suppliers { get; set; }

        public GetSupplierListQueryResponse()
            : base() { }

        public GetSupplierListQueryResponse(List<SupplierViewModel> supplierViewModelList)
            : base() => Suppliers = supplierViewModelList;

        public GetSupplierListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
