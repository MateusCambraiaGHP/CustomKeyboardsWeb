using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.CreateCustomer;
using CustomKeyboardsWeb.Application.Features.Customers.Commands.UpdateCustomer;
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
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
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
            var currentCustomer = await _mediator.Send(new GetCustumerByIdQuery(id));
            return currentCustomer;
        }

        [HttpPost("save")]
        public async Task<CustomerDto> Save(CreateCustomerDto model)
        {
            var currentCustomer = await _mediator.Send(new CreateCustomerCommand(model));
            return currentCustomer;
        }

        [HttpPost("update")]
        public async Task<CustomerDto> Edit(UpdateCustomerDto model)
        {
            var currentCustomer = await _mediator.Send(new UpdateCustomerCommand(model));
            return currentCustomer;
        }
    }
}
