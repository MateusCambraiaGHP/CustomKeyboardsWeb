using CustomKeyboardsWeb.Application.Dtos.Keys;
using CustomKeyboardsWeb.Application.Features.Commands.Keys;
using CustomKeyboardsWeb.Application.Features.Queries.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/key/")]
    [ApiController]
    public class KeyController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public KeyController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
             : base(notifications, mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<GetKeyListQueryResponse> GetAll()
        {
            var currentKeyList = await _mediator.SendQuery(new GetKeyListQuery());
            return currentKeyList;
        }

        [HttpGet("{id}")]
        public async Task<GetKeyByIdQueryResponse> Get(Guid id)
        {
            var currentKey = await _mediator.SendQuery(new GetKeyByIdQuery(id));
            return currentKey;
        }

        [HttpPost("create")]
        public async Task<CreateKeyCommandResponse> Create(CreateKeyDto model)
        {
            var currentKey = await _mediator.SendCommand(new CreateKeyCommand(model));
            return currentKey;
        }

        [HttpPut("update")]
        public async Task<UpdateKeyCommandResponse> Update(UpdateKeyDto model)
        {
            var currentKey = await _mediator.SendCommand(new UpdateKeyCommand(model));
            return currentKey;
        }
    }
}
