using CustomKeyboardsWeb.Application.Features.Commands.Keyboards;
using CustomKeyboardsWeb.Application.Features.Queries.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/teclado/")]
    [ApiController]
    public class KeyboardController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public KeyboardController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetKeyboardListQueryResponse> GetAll()
        {
            var currentKeyboardList = await _mediator.SendQuery(new GetKeyboardListQuery());
            return currentKeyboardList;
        }

        [HttpGet("{id}")]
        public async Task<GetKeyboardByIdQueryResponse> Get(Guid id)
        {
            var currentKeyboard = await _mediator.SendQuery(new GetKeyboardByIdQuery(id));
            return currentKeyboard;
        }

        [HttpPost("save")]
        public async Task<CreateKeyboardCommandResponse> Save(KeyboardViewModel model)
        {
            var currentKeyboard = await _mediator.SendCommand(new CreateKeyboardCommand(model));
            return currentKeyboard;
        }

        [HttpPut("update")]
        public async Task<UpdateKeyboardCommandResponse> Edit(KeyboardViewModel model)
        {
            var currentKeyboard = await _mediator.SendCommand(new UpdateKeyboardCommand(model));
            return currentKeyboard;
        }
    }
}
