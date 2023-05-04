using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.CreateSwitch;
using CustomKeyboardsWeb.Application.Features.Switch.Commands.UpdateSwitch;
using CustomKeyboardsWeb.Application.Features.Switch.Query.GetSwitchById;
using CustomKeyboardsWeb.Application.Features.Switch.Query.GetSwitchList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/switch/")]
    [ApiController]
    public class SwitchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SwitchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<SwitchDto>> GetAll()
        {
            var currentSwitchList = await _mediator.Send(new GetSwitchListQuery());
            return currentSwitchList;
        }

        [HttpGet("{id}")]
        public async Task<SwitchDto> Get(int id)
        {
            var currentSwitch = await _mediator.Send(new GetSwitchByIdQuery(id));
            return currentSwitch;
        }

        [HttpPost("save")]
        public async Task<SwitchDto> Save(CreateSwitchDto model)
        {
            var currentSwitch = await _mediator.Send(new CreateSwitchCommand(model));
            return currentSwitch;
        }

        [HttpPost("update")]
        public async Task<SwitchDto> Edit(UpdateSwitchDto model)
        {
            var currentSwitch = await _mediator.Send(new UpdateSwitchCommand(model));
            return currentSwitch;
        }

    }
}
