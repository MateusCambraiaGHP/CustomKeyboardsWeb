using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer;
using CustomKeyboardsWeb.Application.Features.Customers.Queries.GetCustomerById;
using CustomKeyboardsWeb.Application.Features.Customers.Queries.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/cliente/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMediator _mediator;

        public CustomerController(
            ICustomerService customerService,
            IMediator mediator)
        {
            _customerService = customerService;
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<List<CustomerDto>> GetAll()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());
            return customers;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<CustomerDto> GetById(int id)
        {
            return await _mediator.Send(new GetCustumerByIdQuery(id));
        }

        [HttpPost("save")]
        public async Task<CustomerDto> Save(CustomerDto model)
        {
            return await _mediator.Send(new CreateCustomerCommand(model));
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<CustomerDto> Edit(CustomerDto model)
        {
            return await _customerService.Edit(model);
        }

    }
}
