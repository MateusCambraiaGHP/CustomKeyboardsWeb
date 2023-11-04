using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Responses.Login
{
    public class TryLoginCommandResponse : BaseHandlerResponse
    {
        public string Token { get; set; }

        public TryLoginCommandResponse() { }

        public TryLoginCommandResponse(string token)
            : base() => Token = token;

        public TryLoginCommandResponse(bool success, string message = "")
            : base(success, message) { }
    }
}
