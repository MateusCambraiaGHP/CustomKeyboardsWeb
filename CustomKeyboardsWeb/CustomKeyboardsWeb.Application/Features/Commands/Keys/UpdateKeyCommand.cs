using CustomKeyboardsWeb.Application.Dtos.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys
{
    public class UpdateKeyCommand : Command<UpdateKeyCommandResponse>
    {
        public UpdateKeyDto KeyDto { get; init; }

        public UpdateKeyCommand(UpdateKeyDto model) => KeyDto = model;
    }
}
