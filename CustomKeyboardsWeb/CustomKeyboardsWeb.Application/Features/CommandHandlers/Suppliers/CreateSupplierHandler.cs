using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers;
using CustomKeyboardsWeb.Application.Features.Events;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.Validations.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Communication.Mediator.Interfaces;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Suppliers
{
    public class CreateSupplierHandler : Handler<CreateSupplierCommand, CreateSupplierCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IMediatorHandler _mediatorHandler;

        public CreateSupplierHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler)
            :base(mapper)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
            _mediatorHandler = mediatorHandler;
        }

        public override async Task<CreateSupplierCommandResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var supplier = Supplier.Create(
                    Name.Create(request.SupplierViewModel.Name),
                    FantasyName.Create(request.SupplierViewModel.FantasyName),
                    Cep.Create(request.SupplierViewModel.Cep),
                    Address.Create(request.SupplierViewModel.Adress),
                    FederativeUnit.Create(request.SupplierViewModel.FederativeUnit),
                    Phone.Create(request.SupplierViewModel.Phone),
                    request.SupplierViewModel.Active);

                var @event = new CreateCustomerEvent(supplier);
                _mediatorHandler.PublishEvent(@event);

                await _supplierRepository.Create(supplier);
                await _unitOfWork.CommitChangesAsync();
                var supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);
                
                return new CreateSupplierCommandResponse(supplierViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(CreateSupplierCommand request)
        {
            var erros = await new CreateSupplierCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
