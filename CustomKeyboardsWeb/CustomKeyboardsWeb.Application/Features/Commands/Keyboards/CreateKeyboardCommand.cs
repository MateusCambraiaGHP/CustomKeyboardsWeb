using CustomKeyboardsWeb.Application.Dtos.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards
{
    public class CreateKeyboardCommand : Command<CreateKeyboardCommandResponse>
    {
        public CreateKeyboardDto KeyboardDto { get; set; }

        public CreateKeyboardCommand(CreateKeyboardDto model) => KeyboardDto = model;
    }
}
