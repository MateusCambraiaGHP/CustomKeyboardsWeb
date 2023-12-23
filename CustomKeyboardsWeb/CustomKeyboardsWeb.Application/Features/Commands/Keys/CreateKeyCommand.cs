using CustomKeyboardsWeb.Application.Dtos.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keys
{
    public class CreateKeyCommand : Command<CreateKeyCommandResponse>
    {
        public CreateKeyDto KeyDto { get; init; }

        public CreateKeyCommand(CreateKeyDto model) => KeyDto = model;
    }
}
