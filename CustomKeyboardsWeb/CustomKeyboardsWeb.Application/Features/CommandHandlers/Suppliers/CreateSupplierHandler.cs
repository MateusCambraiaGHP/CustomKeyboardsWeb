using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers;
using CustomKeyboardsWeb.Application.Features.Events;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.Validations.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Suppliers
{
    public class CreateSupplierHandler : Handler<CreateSupplierCommand, CreateSupplierCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSupplierHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CreateSupplierCommandResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on create supplier", request.ValidationResult);

                var supplier = Supplier.Create(
                    Name.Create(request.SupplierDto.Name),
                    FantasyName.Create(request.SupplierDto.FantasyName),
                    Cep.Create(request.SupplierDto.Cep),
                    Address.Create(request.SupplierDto.Adress),
                    FederativeUnit.Create(request.SupplierDto.FederativeUnit),
                    Phone.Create(request.SupplierDto.Phone),
                    request.SupplierDto.Active);

                supplier.AddEvent(new CreateCustomerEvent(supplier));

                await _supplierRepository.Create(supplier);
                await _unitOfWork.CommitChangesAsync();
                var supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);
                
                return new CreateSupplierCommandResponse(supplierViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(CreateSupplierCommand request)
        {
            var erros = new CreateSupplierCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
