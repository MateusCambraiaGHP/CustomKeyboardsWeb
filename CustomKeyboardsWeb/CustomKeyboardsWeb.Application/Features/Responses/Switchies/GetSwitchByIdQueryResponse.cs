using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Switchies
{
    public class GetSwitchByIdQueryResponse : BaseHandlerResponse
    {
        public SwitchDto Switch { get; set; }

        public GetSwitchByIdQueryResponse()
            : base() { }

        public GetSwitchByIdQueryResponse(SwitchDto switchViewModel)
            : base() => Switch = switchViewModel;

        public GetSwitchByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
