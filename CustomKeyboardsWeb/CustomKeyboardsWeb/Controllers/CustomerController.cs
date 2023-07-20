using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Customers;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/cliente/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public CustomerController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetCustomerListQueryResponse> GetAll()
        {
            var customers = await _mediator.SendQuery(new GetCustomerListQuery());
            return customers;
        }

        [HttpGet("{id}")]
        public async Task<GetCustomerByIdQueryResponse> GetById(int id)
        {
            var currentCustomer = await _mediator.SendQuery(new GetCustumerByIdQuery(id));
            return currentCustomer;
        }

        [HttpPost("save")]
        public async Task<CreateCustomerCommandResponse> Save(CustomerViewModel model)
        {
            var currentCustomer = await _mediator.SendCommand(new CreateCustomerCommand(model));
            return currentCustomer;
        }

        [HttpPost("update")]
        public async Task<UpdateCustomerCommandResponse> Edit(CustomerViewModel model)
        {
            var currentCustomer = await _mediator.SendCommand(new UpdateCustomerCommand(model));
            return currentCustomer;
        }
    }
}
