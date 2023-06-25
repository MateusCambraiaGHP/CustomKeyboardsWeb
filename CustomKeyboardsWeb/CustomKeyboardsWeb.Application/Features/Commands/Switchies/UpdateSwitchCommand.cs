using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies
{
    public class UpdateSwitchCommand : Command<UpdateSwitchCommandResponse>
    {
        public SwitchViewModel SwitchViewModel { get; set; }

        public UpdateSwitchCommand(SwitchViewModel model) => SwitchViewModel = model;
    }
}
