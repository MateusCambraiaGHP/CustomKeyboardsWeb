using CustomKeyboardsWeb.Application.Dtos.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies
{
    public class UpdateSwitchCommand : Command<UpdateSwitchCommandResponse>
    {
        public UpdateSwitchDto SwitchDto { get; set; }

        public UpdateSwitchCommand(UpdateSwitchDto model) => SwitchDto = model;
    }
}
