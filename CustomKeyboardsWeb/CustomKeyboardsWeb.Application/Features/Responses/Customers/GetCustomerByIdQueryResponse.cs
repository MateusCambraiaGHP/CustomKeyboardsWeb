using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Customers
{
    public class GetCustomerByIdQueryResponse : BaseHandlerResponse
    {
        public CustomerViewModel Customer { get; set; }

        public GetCustomerByIdQueryResponse()
            : base() { }

        public GetCustomerByIdQueryResponse(CustomerViewModel customerViewModel)
            : base() => Customer = customerViewModel;

        public GetCustomerByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
