using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Commands.Switchies
{
    public class CreateSwitchCommand : Command<CreateSwitchCommandResponse>
    {
        public SwitchViewModel SwitchViewModel { get; set; }

        public CreateSwitchCommand(SwitchViewModel model) => SwitchViewModel = model;
    }
}
