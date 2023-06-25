using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Keys
{
    public class GetKeyListQueryResponse : BaseHandlerResponse
    {
        public List<KeyViewModel> Keys { get; set; }

        public GetKeyListQueryResponse()
            : base() { }

        public GetKeyListQueryResponse(List<KeyViewModel> keyListViewModel)
            : base() => Keys = keyListViewModel;

        public GetKeyListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
