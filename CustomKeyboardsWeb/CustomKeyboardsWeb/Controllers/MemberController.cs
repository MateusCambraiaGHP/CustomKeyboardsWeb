using CustomKeyboardsWeb.Application.Dtos.Members;
using CustomKeyboardsWeb.Application.Features.Commands.Members;
using CustomKeyboardsWeb.Application.Features.Queries.Members;
using CustomKeyboardsWeb.Application.Features.Responses.Members;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/member/")]
    [ApiController]
    public class MemberController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public MemberController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
             : base(notifications, mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<GetMemberListQueryResponse> GetAll()
        {
            var members = await _mediator.SendQuery(new GetMemberListQuery());
            return members;
        }

        [HttpGet("{id}")]
        public async Task<GetMemberByIdQueryResponse> GetById(Guid id)
        {
            var currentMember = await _mediator.SendQuery(new GetMemberByIdQuery(id));
            return currentMember;
        }

        [HttpPost("create")]
        public async Task<CreateMemberCommandResponse> Create(CreateMemberDto model)
        {
            var currentMember = await _mediator.SendCommand(new CreateMemberCommand(model));
            return currentMember;
        }

        [HttpPut("update")]
        public async Task<UpdateMemberCommandResponse> Update(UpdateMemberDto model)
        {
            var currentMember = await _mediator.SendCommand(new UpdateMemberCommand(model));
            return currentMember;
        }
    }
}
