using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Switchies
{
    public class GetSwitchListQueryResponse : BaseHandlerResponse
    {
        public List<SwitchDto> Switchies { get; set; }

        public GetSwitchListQueryResponse()
            : base() { }

        public GetSwitchListQueryResponse(List<SwitchDto> switchViewModelList)
            : base() => Switchies = switchViewModelList;

        public GetSwitchListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}