using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Switchies
{
    public class GetSwitchByIdQueryResponse : BaseHandlerResponse
    {
        public SwitchViewModel Switch { get; set; }

        public GetSwitchByIdQueryResponse()
            : base() { }

        public GetSwitchByIdQueryResponse(SwitchViewModel switchViewModel)
            : base() => Switch = switchViewModel;

        public GetSwitchByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
