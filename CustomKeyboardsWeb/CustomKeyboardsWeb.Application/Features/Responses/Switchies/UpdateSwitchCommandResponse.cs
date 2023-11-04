using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Switchies
{
    public class UpdateSwitchCommandResponse : BaseHandlerResponse
    {
        public SwitchDto Switch { get; set; }

        public UpdateSwitchCommandResponse() { }

        public UpdateSwitchCommandResponse(SwitchDto @switch)
            : base() => Switch = @switch;

        public UpdateSwitchCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
