using MediatR;

namespace CustomKeyboardsWeb.Core.Messages
{
    public abstract class BaseEventHandler<TEvent> : IDisposable, INotificationHandler<TEvent>
        where TEvent : Event
    {
        public BaseEventHandler() { }

        public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);

        protected abstract void PostErrorLog(string message);

        protected abstract void PostInfoLog(string message);

        public virtual void Dispose() { }
    }
}
