using MediatR;

namespace CustomKeyboardsWeb.Core.Messages.CommonMessages
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event() => Timestamp = DateTime.UtcNow;
    }
}
