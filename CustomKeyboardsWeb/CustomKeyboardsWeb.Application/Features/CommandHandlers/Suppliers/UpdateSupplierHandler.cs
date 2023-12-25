using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Commands.Suppliers;
using CustomKeyboardsWeb.Application.Features.Responses.Suppliers;
using CustomKeyboardsWeb.Application.Features.Validations.Suppliers;
using CustomKeyboardsWeb.Application.Features.ViewModel.Suppliers;
using CustomKeyboardsWeb.Core.Data;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers;
using FluentValidation.Results;

namespace CustomKeyboardsWeb.Application.Features.CommandHandlers.Suppliers
{
    public class UpdateSupplierHandler : Handler<UpdateSupplierCommand, UpdateSupplierCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public UpdateSupplierHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICacheService cacheService)
            : base(mapper)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public override async Task<UpdateSupplierCommandResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.ValidationResult = Validate(request);

                if (!request.IsValid())
                    return ResponseOnFailValidation("fail on update supplier", request.ValidationResult);

                var supplierMap = _mapper.Map<Supplier>(request.SupplierDto);
                await _supplierRepository.Update(supplierMap);
                await _unitOfWork.CommitChangesAsync();
                var supplierViewModel = _mapper.Map<SupplierViewModel>(request);
                _cacheService.RemovePost(nameof(SupplierViewModel), nameof(SupplierViewModel));

                return new UpdateSupplierCommandResponse(supplierViewModel);
            }
            catch (Exception ex)
            {
                return ResponseOnFailValidation(ex.Message, request.ValidationResult);
            }
        }

        public override List<ValidationFailure> Validate(UpdateSupplierCommand request)
        {
            var erros = new UpdateSupplierCommandValidation().Validate(request);
            return erros.Errors;
        }
    }
}
