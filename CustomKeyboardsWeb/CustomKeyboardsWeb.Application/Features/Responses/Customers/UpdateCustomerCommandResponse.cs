using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;


namespace CustomKeyboardsWeb.Application.Features.Responses.Customers
{
    public class UpdateCustomerCommandResponse : BaseHandlerResponse
    {
        public CustomerViewModel Customer { get; set; }

        public UpdateCustomerCommandResponse() { }

        public UpdateCustomerCommandResponse(CustomerViewModel customer)
            : base() => Customer = customer;

        public UpdateCustomerCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
