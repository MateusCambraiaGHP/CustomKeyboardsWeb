using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Keyboards
{
    public class GetKeyboardByIdQueryResponse : BaseHandlerResponse
    {
        public KeyboardViewModel Keyboard { get; set; }

        public GetKeyboardByIdQueryResponse()
            : base() { }

        public GetKeyboardByIdQueryResponse(KeyboardViewModel keyboardViewModel)
            : base() => Keyboard = keyboardViewModel;

        public GetKeyboardByIdQueryResponse(bool success, string message)
            : base(success, message) { }
    }
}

