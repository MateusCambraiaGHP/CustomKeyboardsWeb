using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Customers
{
    public class CreateCustomerCommandResponse : BaseHandlerResponse
    {
        public CustomerViewModel Customer { get; set; }

        public CreateCustomerCommandResponse() { }

        public CreateCustomerCommandResponse(CustomerViewModel customer)
            : base() => Customer = customer;

        public CreateCustomerCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
