using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys
{
    public class CreateKeyCommand : Command<CreateKeyCommandResponse>
    {
        public KeyViewModel KeyViewModel { get; set; }

        public CreateKeyCommand(KeyViewModel model) => KeyViewModel = model;
    }
}
