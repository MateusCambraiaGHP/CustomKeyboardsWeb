using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers.CreateSupplier;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers.UpdateSupplier;
using CustomKeyboardsWeb.Application.Features.Queries.Suppliers.GetSupplierById;
using CustomKeyboardsWeb.Application.Features.Queries.Suppliers.GetSupplierList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/fornecedor/")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<SupplierDto>> GetAll()
        {
            var currentSupplierList = await _mediator.Send(new GetSupplierListQuery());
            return currentSupplierList;
        }

        [HttpGet("{id}")]
        public async Task<SupplierDto> Get(int id)
        {
            var currentSupplier = await _mediator.Send(new GetSupplierByIdQuery(id));
            return currentSupplier;
        }

        [HttpPost("save")]
        public async Task<SupplierDto> Save(CreateSupplierDto model)
        {
            var currentSupplier = await _mediator.Send(new CreateSupplierCommand(model));
            return currentSupplier;
        }

        [HttpPost("update")]
        public async Task<SupplierDto> Edit(UpdateSupplierDto model)
        {
            var currentSupplier = await _mediator.Send(new UpdateSupplierCommand(model));
            return currentSupplier;
        }

    }
}
