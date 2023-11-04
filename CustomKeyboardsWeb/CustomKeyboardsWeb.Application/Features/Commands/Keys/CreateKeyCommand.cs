using CustomKeyboardsWeb.Application.Dtos.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys
{
    public class CreateKeyCommand : Command<CreateKeyCommandResponse>
    {
        public KeyDto KeyDto { get; set; }

        public CreateKeyCommand(KeyDto model) => KeyDto = model;
    }
}
