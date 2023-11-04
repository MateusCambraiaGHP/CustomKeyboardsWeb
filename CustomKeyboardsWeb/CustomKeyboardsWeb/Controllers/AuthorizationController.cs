using CustomKeyboardsWeb.Application.Features.Commands.Login;
using CustomKeyboardsWeb.Application.Features.Responses.Login;
using CustomKeyboardsWeb.Application.Features.ViewModel.Login;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/authorization/")]
    [ApiController]
    public class AuthorizationController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public AuthorizationController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
             : base(notifications, mediator) => _mediator = mediator;

        [AllowAnonymous]
        [HttpPost("authorize")]
        public async Task<TryLoginCommandResponse> GetBearerToken(LoginViewModel model)
        {
            var currentToken = await _mediator.SendCommand(new TryLoginCommand(model));
            return currentToken;
        }
    }
}
