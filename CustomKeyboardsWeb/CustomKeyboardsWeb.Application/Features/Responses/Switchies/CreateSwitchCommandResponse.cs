using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Switchies
{
    public class CreateSwitchCommandResponse : BaseHandlerResponse
    {
        public SwitchDto Switch { get; set; }

        public CreateSwitchCommandResponse() { }

        public CreateSwitchCommandResponse(SwitchDto @switch)
            : base() => Switch = @switch;

        public CreateSwitchCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
