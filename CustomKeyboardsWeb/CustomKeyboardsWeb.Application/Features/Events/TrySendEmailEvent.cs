using CustomKeyboardsWeb.Core.Messages.CommonMessages;

namespace CustomKeyboardsWeb.Application.Features.Events
{
    public class TrySendEmailEvent : Event
    {
        public string BodyEmail { get; set; }

        public TrySendEmailEvent(string bodyEmail) => BodyEmail = bodyEmail;
    }
}
