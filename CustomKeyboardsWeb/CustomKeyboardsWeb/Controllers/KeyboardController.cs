using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards.CreateKeyboard;
using CustomKeyboardsWeb.Application.Features.Commands.Keyboards.UpdateKeyboard;
using CustomKeyboardsWeb.Application.Features.Queries.Keyboards.GetKeyboardById;
using CustomKeyboardsWeb.Application.Features.Queries.Keyboards.GetKeyboardList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/teclado/")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeyboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<List<KeyboardDto>> GetAll()
        {
            var currentKeyboardList = await _mediator.Send(new GetKeyboardListQuery());
            return currentKeyboardList;
        }

        [HttpGet("{id}")]
        public async Task<KeyboardDto> Get(int id)
        {
            var currentKeyboard = await _mediator.Send(new GetKeyboardByIdQuery(id));
            return currentKeyboard;
        }

        [HttpPost("save")]
        public async Task<KeyboardDto> Save(CreateKeyboardDto model)
        {
            var currentKeyboard = await _mediator.Send(new CreateKeyboardCommand(model));
            return currentKeyboard;
        }

        [HttpPost("update")]
        public async Task<KeyboardDto> Edit(UpdateKeyboardDto model)
        {
            var currentKeyboard = await _mediator.Send(new UpdateKeyboardCommand(model));
            return currentKeyboard;
        }

    }
}
