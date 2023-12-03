using CustomKeyboardsWeb.Application.Dtos.Customers;
using CustomKeyboardsWeb.Application.Features.Commands.Customers;
using CustomKeyboardsWeb.Application.Features.Queries.Customers;
using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/customer/")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public CustomerController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
             : base(notifications, mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<GetCustomerListQueryResponse> GetAll()
        {
            var customers = await _mediator.SendQuery(new GetCustomerListQuery());
            return customers;
        }

        [HttpGet("{id}")]
        public async Task<GetCustomerByIdQueryResponse> GetById(Guid id)
        {
            var currentCustomer = await _mediator.SendQuery(new GetCustumerByIdQuery(id));
            return currentCustomer;
        }

        [HttpPost("create")]
        public async Task<CreateCustomerCommandResponse> Create(CreateCustomerDto model)
        {
            var currentCustomer = await _mediator.SendCommand(new CreateCustomerCommand(model));
            return currentCustomer;
        }

        [HttpPut("update")]
        public async Task<UpdateCustomerCommandResponse> Update(UpdateCustomerDto model)
        {
            var currentCustomer = await _mediator.SendCommand(new UpdateCustomerCommand(model));
            return currentCustomer;
        }
    }
}
