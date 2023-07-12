using MediatR;

namespace CustomKeyboardsWeb.Mediator.Abstractions.Messages
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
