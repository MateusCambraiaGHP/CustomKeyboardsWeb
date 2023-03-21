using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/switch/")]
    [ApiController]
    public class SwitchController : ControllerBase
    {
        private readonly ISwitchService _switchService;

        public SwitchController(
            ISwitchService switchService)
        {
            _switchService = switchService;
        }

        [HttpGet]
        public async Task<List<SwitchDto>> Get()
        {
            return await _switchService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<SwitchDto> Get(int id)
        {
            return await _switchService.FindByIdAsync(id);
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public async Task<SwitchDto> Save(SwitchDto model)
        {
            return await _switchService.Save(model);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<SwitchDto> Edit(SwitchDto model)
        {
            return await _switchService.Edit(model);
        }

    }
}
