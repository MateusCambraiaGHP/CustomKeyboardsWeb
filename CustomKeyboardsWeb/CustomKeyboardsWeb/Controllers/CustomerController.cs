using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/cliente/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetAll()
        {
            return await _customerService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<CustomerDto> GetById(int id)
        {
            return await _customerService.FindByIdAsync(id);
        }

        [HttpPost("save")]
        public async Task<CustomerDto> Save(CustomerDto model)
        {
            return await _customerService.Save(model);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<CustomerDto> Edit(CustomerDto model)
        {
            return await _customerService.Edit(model);
        }

    }
}
