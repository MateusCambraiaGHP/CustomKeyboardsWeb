using CustomKeyboardsWeb.Application.Dtos.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Keyboards
{
    public class UpdateKeyboardCommand : Command<UpdateKeyboardCommandResponse>
    {
        public KeyboardDto KeyboardDto { get; set; }

        public UpdateKeyboardCommand(KeyboardDto model) => KeyboardDto = model;
    }
}
