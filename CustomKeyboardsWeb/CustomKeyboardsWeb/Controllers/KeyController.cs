using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/tecla/")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly IKeyService _keyService;

        public KeyController(
            IKeyService keyService)
        {
            _keyService = keyService;
        }

        [HttpGet]
        public async Task<List<KeyDto>> Get()
        {
            return await _keyService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<KeyDto> Get(int id)
        {
            return await _keyService.FindByIdAsync(id);
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public async Task<KeyDto> Save(KeyDto model)
        {
            return await _keyService.Save(model);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<KeyDto> Edit(KeyDto model)
        {
            return await _keyService.Edit(model);
        }

    }
}
