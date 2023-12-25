using CustomKeyboardsWeb.Core.Communication.Mediator;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected BaseController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected bool isValid()
        {
            return !_notifications.HasNotifications();
        }

        protected IEnumerable<string> GetMessagesError()
        {
            return _notifications
                .GetNotifications()
                .Select(c => c.Value)
                .ToList();
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.PublishNotification(new DomainNotification(code, message));
        }
    }
}
