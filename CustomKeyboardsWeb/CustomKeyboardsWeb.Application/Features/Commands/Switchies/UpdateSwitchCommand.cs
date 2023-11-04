using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies
{
    public class UpdateSwitchCommand : Command<UpdateSwitchCommandResponse>
    {
        public SwitchDto SwitchDto { get; set; }

        public UpdateSwitchCommand(SwitchDto model) => SwitchDto = model;
    }
}
