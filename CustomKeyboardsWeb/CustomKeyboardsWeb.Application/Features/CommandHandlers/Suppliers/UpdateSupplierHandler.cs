using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.Validations.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Suppliers
{
    public class UpdateSupplierHandler : Handler<UpdateSupplierCommand, UpdateSupplierCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            :base(mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<UpdateSupplierCommandResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = await Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("", request.ValidationResult);

                var supplierMap = _mapper.Map<Supplier>(request.SupplierViewModel);
                supplierMap.CreatedAt = DateTime.UtcNow;
                supplierMap.CreatedBy = "Administrator";
                await _supplierRepository.Update(supplierMap);
                await _unitOfWork.CommitChangesAsync();
                var supplierViewModel = _mapper.Map<SupplierViewModel>(request);

                return new UpdateSupplierCommandResponse(supplierViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<ValidationFailure>> Validate(UpdateSupplierCommand request)
        {
            var erros = await new UpdateSupplierCommandValidation().ValidateAsync(request);
            return erros.Errors;
        }
    }
}
