using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Customers
{
    public class UpdateCustomerCommand : Command<UpdateCustomerCommandResponse>
    {
        public CustomerViewModel CustomerViewModel { get; set; }

        public UpdateCustomerCommand(CustomerViewModel model) => CustomerViewModel = model;
    }
}
