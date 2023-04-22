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

        [HttpGet("getall")]
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
            if (model.Active.Length > 1)
            {
                ModelState.AddModelError("active", "MUITO GRANDE.");
                if (!ModelState.IsValid)
                {
                    model.Errors = ModelState.ToDictionary(
             kvp => kvp.Key,
             kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                    return model;
                }

            }
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
