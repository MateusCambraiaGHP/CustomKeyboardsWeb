using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Keyboards
{
    public class GetKeyboardListQueryResponse : BaseHandlerResponse
    {
        public List<KeyboardViewModel> Keyboards { get; set; }

        public GetKeyboardListQueryResponse()
            : base() { }
        public GetKeyboardListQueryResponse(List<KeyboardViewModel> keyboardViewModelList)
            : base() => Keyboards = keyboardViewModelList;

        public GetKeyboardListQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}
