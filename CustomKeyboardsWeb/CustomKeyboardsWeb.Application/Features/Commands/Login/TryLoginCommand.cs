using CustomKeyboardsWeb.Application.Features.Responses.Login;
using CustomKeyboardsWeb.Application.Features.ViewModel.Login;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Login
{
    public class TryLoginCommand : Command<TryLoginCommandResponse>
    {
        public LoginViewModel LoginViewModel { get; set; }

        public TryLoginCommand(LoginViewModel model) => LoginViewModel = model;
    }
}
