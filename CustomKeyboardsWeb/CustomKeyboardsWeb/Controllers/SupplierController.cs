﻿using CustomKeyboardsWeb.Application.Features.Commands.Suppliers;
using CustomKeyboardsWeb.Application.Features.Queries.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomKeyboardsWeb.Controllers
{
    [Route("api/v1.0/supplier/")]
    [ApiController]
    public class SupplierController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public SupplierController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetSupplierListQueryResponse> GetAll()
        {
            var currentSupplierList = await _mediator.SendQuery(new GetSupplierListQuery());
            return currentSupplierList;
        }

        [HttpGet("{id}")]
        public async Task<GetSupplierByIdQueryResponse> Get(Guid id)
        {
            var currentSupplier = await _mediator.SendQuery(new GetSupplierByIdQuery(id));
            return currentSupplier;
        }

        [HttpPost("save")]
        public async Task<CreateSupplierCommandResponse> Save(SupplierViewModel model)
        {
            var currentSupplier = await _mediator.SendCommand(new CreateSupplierCommand(model));
            return currentSupplier;
        }

        [HttpPut("update")]
        public async Task<UpdateSupplierCommandResponse> Edit(SupplierViewModel model)
        {
            var currentSupplier = await _mediator.SendCommand(new UpdateSupplierCommand(model));
            return currentSupplier;
        }
    }
}
