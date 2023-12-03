using CustomKeyboardsWeb.Application.Dtos.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies
{
    public class CreateSwitchCommand : Command<CreateSwitchCommandResponse>
    {
        public CreateSwitchDto SwitchDto { get; set; }

        public CreateSwitchCommand(CreateSwitchDto model) => SwitchDto = model;
    }
}
