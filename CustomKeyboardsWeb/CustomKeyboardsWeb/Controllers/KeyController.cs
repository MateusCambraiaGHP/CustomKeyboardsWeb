using CustomKeyboardsWeb.Application.Features.Commands.Keys;
using CustomKeyboardsWeb.Application.Features.Queries.Keys;
using CustomKeyboardsWeb.Application.Features.Responses.Keys;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keys;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/tecla/")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public KeyController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetKeyListQueryResponse> GetAll()
        {
            var currentKeyList = await _mediator.SendQuery(new GetKeyListQuery());
            return currentKeyList;
        }

        [HttpGet("{id}")]
        public async Task<GetKeyByIdQueryResponse> Get(int id)
        {
            var currentKey = await _mediator.SendQuery(new GetKeyByIdQuery(id));
            return currentKey;
        }

        [HttpPost("save")]
        public async Task<CreateKeyCommandResponse> Save(KeyViewModel model)
        {
            var currentKey = await _mediator.SendCommand(new CreateKeyCommand(model));
            return currentKey;
        }

        [HttpPost("update")]
        public async Task<UpdateKeyCommandResponse> Edit(KeyViewModel model)
        {
            var currentKey = await _mediator.SendCommand(new UpdateKeyCommand(model));
            return currentKey;
        }
    }
}
