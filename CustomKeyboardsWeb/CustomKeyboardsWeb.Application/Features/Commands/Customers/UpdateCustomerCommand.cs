using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers
{
    public class UpdateCustomerCommand : Command<UpdateCustomerCommandResponse>
    {
        public CustomerViewModel CustomerViewModel { get; set; }

        public UpdateCustomerCommand(CustomerViewModel model) => CustomerViewModel = model;
    }
}
