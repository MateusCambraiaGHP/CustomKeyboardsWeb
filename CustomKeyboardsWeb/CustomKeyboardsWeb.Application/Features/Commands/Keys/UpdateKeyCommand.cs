using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys
{
    public class UpdateKeyCommand : Command<UpdateKeyCommandResponse>
    {
        public KeyViewModel KeyViewModel { get; set; }

        public UpdateKeyCommand(KeyViewModel model) => KeyViewModel = model;
    }
}
