using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Keys
{
    public class GetKeyByIdQueryResponse : BaseHandlerResponse
    {
        public KeyViewModel Key { get; set; }

        public GetKeyByIdQueryResponse()
            : base() { }

        public GetKeyByIdQueryResponse(KeyViewModel keyViewModel)
            : base() => Key = keyViewModel;

        public GetKeyByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
