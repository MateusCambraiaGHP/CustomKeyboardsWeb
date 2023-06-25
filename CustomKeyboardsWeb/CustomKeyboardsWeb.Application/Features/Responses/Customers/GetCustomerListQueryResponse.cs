using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

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
