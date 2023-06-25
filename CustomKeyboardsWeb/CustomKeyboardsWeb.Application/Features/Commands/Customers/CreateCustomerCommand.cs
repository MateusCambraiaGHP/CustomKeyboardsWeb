using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers
{
    public class CreateCustomerCommand : Command<CreateCustomerCommandResponse>
    {
        public CustomerViewModel CustomerViewModel { get; set; }

        public CreateCustomerCommand(CustomerViewModel model) => CustomerViewModel = model;
    }
}
