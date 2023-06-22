using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers.UpdateSupplier
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierDto> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supplierMap = _mapper.Map<Supplier>(request.UpdateSupplierDto);
                supplierMap.CreatedAt = DateTime.UtcNow;
                supplierMap.CreatedBy = "Administrator";
                await _supplierRepository.Update(supplierMap);
                await _unitOfWork.CommitChangesAsync();
                var supplierDtoMap = _mapper.Map<SupplierDto>(request.UpdateSupplierDto);
                return supplierDtoMap;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
