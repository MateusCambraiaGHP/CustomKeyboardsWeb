using CustomKeyboardsWeb.Application.Dtos.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys
{
    public class UpdateKeyCommand : Command<UpdateKeyCommandResponse>
    {
        public KeyDto KeyDto { get; set; }

        public UpdateKeyCommand(KeyDto model) => KeyDto = model;
    }
}
