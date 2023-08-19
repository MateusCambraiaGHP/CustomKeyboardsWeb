using CustomKeyboardsWeb.Application.Features.Commands.Switchies;
using CustomKeyboardsWeb.Application.Features.Queries.Switchies;
using CustomKeyboardsWeb.Application.Features.Responses.Switchies;
using CustomKeyboardsWeb.Application.Features.ViewModel.Switchies;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/switch/")]
    [ApiController]
    public class SwitchController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public SwitchController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

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

        [HttpPost("save")]
        public async Task<CreateSwitchCommandResponse> Save(SwitchViewModel model)
        {
            var currentSwitch = await _mediator.SendCommand(new CreateSwitchCommand(model));
            return currentSwitch;
        }

        [HttpPost("update")]
        public async Task<UpdateSwitchCommandResponse> Edit(SwitchViewModel model)
        {
            var currentSwitch = await _mediator.SendCommand(new UpdateSwitchCommand(model));
            return currentSwitch;
        }
    }
}
