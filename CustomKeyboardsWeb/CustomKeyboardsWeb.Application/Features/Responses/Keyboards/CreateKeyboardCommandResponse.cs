using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;


namespace CustomKeyboardsWeb.Application.Features.Responses.Keyboards
{
    public class CreateKeyboardCommandResponse : BaseHandlerResponse
    {
        public KeyboardViewModel Keyboard { get; set; }

        public CreateKeyboardCommandResponse() { }

        public CreateKeyboardCommandResponse(KeyboardViewModel keyboard)
            : base() => Keyboard = keyboard;

        public CreateKeyboardCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
