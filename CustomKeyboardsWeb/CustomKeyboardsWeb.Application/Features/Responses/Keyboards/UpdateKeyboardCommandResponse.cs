using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;


namespace CustomKeyboardsWeb.Application.Features.Responses.Keyboards
{
    public class UpdateKeyboardCommandResponse : BaseHandlerResponse
    {
        public KeyboardViewModel Keyboard { get; set; }

        public UpdateKeyboardCommandResponse() { }

        public UpdateKeyboardCommandResponse(KeyboardViewModel keyboard)
            : base() => Keyboard = keyboard;

        public UpdateKeyboardCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
