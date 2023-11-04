using CustomKeyboardsWeb.Application.Dtos.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards
{
    public class CreateKeyboardCommand : Command<CreateKeyboardCommandResponse>
    {
        public KeyboardDto KeyboardDto { get; set; }

        public CreateKeyboardCommand(KeyboardDto model) => KeyboardDto = model;
    }
}
