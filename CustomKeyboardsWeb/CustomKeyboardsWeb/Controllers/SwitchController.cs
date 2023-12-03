using CustomKeyboardsWeb.Application.Dtos.Switchies;
using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using CustomKeyboardsWeb.Application.Features.Queries.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/switch/")]
    [ApiController]
    public class SwitchController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public SwitchController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
             : base(notifications, mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<GetSwitchListQueryResponse> GetAll()
        {
            var currentSwitchList = await _mediator.SendQuery(new GetSwitchListQuery());
            return currentSwitchList;
        }

        [HttpGet("{id}")]
        public async Task<GetSwitchByIdQueryResponse> Get(Guid id)
        {
            var currentSwitch = await _mediator.SendQuery(new GetSwitchByIdQuery(id));
            return currentSwitch;
        }

        [HttpPost("create")]
        public async Task<CreateSwitchCommandResponse> Create(CreateSwitchDto model)
        {
            var currentSwitch = await _mediator.SendCommand(new CreateSwitchCommand(model));
            return currentSwitch;
        }

        [HttpPut("update")]
        public async Task<UpdateSwitchCommandResponse> Update(UpdateSwitchDto model)
        {
            var currentSwitch = await _mediator.SendCommand(new UpdateSwitchCommand(model));
            return currentSwitch;
        }
    }
}
