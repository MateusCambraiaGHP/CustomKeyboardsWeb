using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages;

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
