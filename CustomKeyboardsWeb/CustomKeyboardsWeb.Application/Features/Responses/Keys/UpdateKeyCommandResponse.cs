using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Mediator.Abstractions.Messages;


namespace CustomKeyboardsWeb.Application.Features.Responses.Keys
{
    public class UpdateKeyCommandResponse : BaseHandlerResponse
    {
        public KeyViewModel Key { get; set; }

        public UpdateKeyCommandResponse() { }

        public UpdateKeyCommandResponse(KeyViewModel key)
            : base() => Key = key;

        public UpdateKeyCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
