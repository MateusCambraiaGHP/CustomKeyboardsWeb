using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Key.Commands.CreateKey;
using CustomKeyboardsWeb.Application.Features.Key.Commands.UpdateKey;
using CustomKeyboardsWeb.Application.Features.Key.Query.GetKeyById;
using CustomKeyboardsWeb.Application.Features.Key.Query.GetKeyList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/tecla/")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<List<KeyDto>> GetAll()
        {
            var currentKeyList = await _mediator.Send(new GetKeyListQuery());
            return currentKeyList;
        }

        [HttpGet("{id}")]
        public async Task<KeyDto> Get(int id)
        {
            var currentKey = await _mediator.Send(new GetKeyByIdQuery(id));
            return currentKey;
        }

        [HttpPost("save")]
        public async Task<KeyDto> Save(CreateKeyDto model)
        {
            var currentKey = await _mediator.Send(new CreateKeyCommand(model));
            return currentKey;
        }

        [HttpPost("update")]
        public async Task<KeyDto> Edit(UpdateKeyDto model)
        {
            var currentKey = await _mediator.Send(new UpdateKeyCommand(model));
            return currentKey;
        }

    }
}
