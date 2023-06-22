using AutoMapper;
using CustomKeyboardsWeb.Application.Cummon.Interfaces;
using CustomKeyboardsWeb.Application.Dto;
using CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects;
using CustomKeyboardsWeb.Domain.Primitives.Entities;
using MediatR;

namespace CustomKeyboardsWeb.Application.Features.Commands.Suppliers.CreateSupplier
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, SupplierDto>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSupplierHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierDto> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supplier = Supplier.Create(
                    Name.Create(request.CreateSupplierDto.Name),
                    FantasyName.Create(request.CreateSupplierDto.FantasyName),
                    Cep.Create(request.CreateSupplierDto.Cep),
                    Address.Create(request.CreateSupplierDto.Adress),
                    FederativeUnit.Create(request.CreateSupplierDto.FederativeUnit),
                    Phone.Create(request.CreateSupplierDto.Phone),
                    request.CreateSupplierDto.Active);

                await _supplierRepository.Create(supplier);
                await _unitOfWork.CommitChangesAsync();
                var supplierDto = _mapper.Map<SupplierDto>(supplier);
                return supplierDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
