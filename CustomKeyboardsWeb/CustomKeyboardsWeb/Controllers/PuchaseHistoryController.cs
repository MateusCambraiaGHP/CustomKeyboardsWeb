using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/historicodecompra/")]
    [ApiController]
    public class PuchaseHistoryController : ControllerBase
    {
        private readonly IPuchaseHistoryService _puchaseHistoryService;

        public PuchaseHistoryController(
            IPuchaseHistoryService puchaseHistoryService)
        {
            _puchaseHistoryService = puchaseHistoryService;
        }

        [HttpGet]
        public async Task<List<PuchaseHistoryDto>> Get()
        {
            return await _puchaseHistoryService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<PuchaseHistoryDto> Get(int id)
        {
            return await _puchaseHistoryService.FindByIdAsync(id);
        }

    }
}
