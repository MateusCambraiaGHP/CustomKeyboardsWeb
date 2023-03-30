using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/fornecedor/")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(
            ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<List<SupplierDto>> Get()
        {
            return await _supplierService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<SupplierDto> Get(int id)
        {
            return await _supplierService.FindByIdAsync(id);
        }

        [HttpPost("save")]
        [ValidateAntiForgeryToken]
        public async Task<SupplierDto> Save(SupplierDto model)
        {
            return await _supplierService.Save(model);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<SupplierDto> Edit(SupplierDto model)
        {
            return await _supplierService.Edit(model);
        }

    }
}
