using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Customers
{
    public class GetCustomerListQueryResponse : BaseHandlerResponse
    {
        public List<CustomerViewModel> Customers { get; set; }

        public GetCustomerListQueryResponse()
            : base() { }

        public GetCustomerListQueryResponse(List<CustomerViewModel> customerListViewModel)
            : base() => Customers = customerListViewModel;

        public GetCustomerListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
