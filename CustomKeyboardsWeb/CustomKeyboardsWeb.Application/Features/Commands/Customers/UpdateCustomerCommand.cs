using CustomKeyboardsWeb.Application.Dtos.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers
{
    public class UpdateCustomerCommand : Command<UpdateCustomerCommandResponse>
    {
        public UpdateCustomerDto CustomerDto { get; set; }

        public UpdateCustomerCommand(UpdateCustomerDto model) => CustomerDto = model;
    }
}
