using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/teclado/")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly IKeyboardService _keyboardService;

        public KeyboardController(
            IKeyboardService keyboardService)
        {
            _keyboardService = keyboardService;
        }

        [HttpGet]
        public async Task<List<KeyboardDto>> Get()
        {
            return await _keyboardService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<KeyboardDto> Get(int id)
        {
            return await _keyboardService.FindByIdAsync(id);
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public async Task<KeyboardDto> Save(KeyboardDto model)
        {
            return await _keyboardService.Save(model);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<KeyboardDto> Edit(KeyboardDto model)
        {
            return await _keyboardService.Edit(model);
        }

    }
}
