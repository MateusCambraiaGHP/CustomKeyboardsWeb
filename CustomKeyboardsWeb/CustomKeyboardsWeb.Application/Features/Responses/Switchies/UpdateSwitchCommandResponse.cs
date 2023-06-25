using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;


namespace CustomKeyboardsWeb.Application.Features.Responses.Switchies
{
    public class UpdateSwitchCommandResponse : BaseHandlerResponse
    {
        public SwitchViewModel Switch { get; set; }

        public UpdateSwitchCommandResponse() { }

        public UpdateSwitchCommandResponse(SwitchViewModel @switch)
            : base() => Switch = @switch;

        public UpdateSwitchCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
