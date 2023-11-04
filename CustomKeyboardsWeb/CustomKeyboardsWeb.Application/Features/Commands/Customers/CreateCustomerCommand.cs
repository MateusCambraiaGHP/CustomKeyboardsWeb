using CustomKeyboardsWeb.Application.Dtos.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers
{
    public class CreateCustomerCommand : Command<CreateCustomerCommandResponse>
    {
        public CustomerDto CustomerDto { get; set; }

        public CreateCustomerCommand(CustomerDto model) => CustomerDto = model;
    }
}
